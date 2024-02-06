using System.Drawing.Drawing2D;

namespace TrilaterationTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private PointF Hit;
        private PointF HitA, HitB, HitC, HitD;
        private PointF HitCalc;

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawPoint(Brushes.Red, Pens.Black, Hit, 3);

            e.Graphics.DrawPoint(Brushes.Blue, Pens.Black, HitA, 3);

            e.Graphics.DrawPoint(Brushes.Green, Pens.Black, HitB, 3);

            e.Graphics.DrawPoint(Brushes.Yellow, Pens.Black, HitC, 3);

            e.Graphics.DrawPoint(Brushes.Purple, Pens.Black, HitD, 3);

            e.Graphics.DrawPoint(Brushes.Orange, Pens.Black, HitCalc, 3);
        }

        //Simulate a hit on the target, calculate realistic sensor values and calculate the hit location
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            int Tx = e.Location.X;
            int Ty = e.Location.Y;

            int target_width = picCanvas.Width;
            int target_height = picCanvas.Height;

            Hit.X = Tx;
            Hit.Y = Ty;

            lb_hitX.Text = string.Format("X {0:d2}", Tx);
            lb_hitY.Text = string.Format("Y {0:d2}", Ty);

            double delayA, delayB, delayC, delayD;

            double sound_speed = 343;// + (0.62f* Convert.ToDouble(tb_airTemp.Text));
            double sound_speed_mmus = sound_speed / 1000;

            lb_soundSpeed.Text = sound_speed.ToString();

            //Simulate sensor timings

            double distanceA = Math.Sqrt((Tx * Tx) + (Ty * Ty));
            double distanceB = Math.Sqrt( Math.Pow(target_width-Tx,2) + Math.Pow(Ty,2));
            double distanceC = Math.Sqrt( Math.Pow(target_width-Tx,2) + Math.Pow(target_height - Ty, 2));
            double distanceD = Math.Sqrt(Math.Pow(Tx, 2) + Math.Pow(target_height - Ty, 2));

            delayA = distanceA / sound_speed_mmus;
            delayB = distanceB / sound_speed_mmus;
            delayC = distanceC / sound_speed_mmus;
            delayD = distanceD / sound_speed_mmus;

            lb_delay_a_actual.Text = delayA.ToString("0.###");
            lb_delay_b_actual.Text = delayB.ToString("0.###");
            lb_delay_c_actual.Text = delayC.ToString("0.###");
            lb_delay_d_actual.Text = delayD.ToString("0.###");

            double min_time = 9999;

            if (delayA < min_time)
                min_time = delayA;
            if (delayB < min_time)
                min_time = delayB;
            if (delayC < min_time)
                min_time = delayC;
            if(delayD < min_time)
                min_time = delayD;

            double measured_a = delayA - min_time;
            double measured_b = delayB - min_time;
            double measured_c = delayC - min_time;
            double measured_d = delayD - min_time;

            lb_delay_a_measured.Text = measured_a.ToString("0.###");
            lb_delay_b_measured.Text = measured_b.ToString("0.###");
            lb_delay_c_measured.Text = measured_c.ToString("0.###");
            lb_delay_d_measured.Text = measured_d.ToString("0.###");

            //Calculate the hit position x,y relative to center of the target based on the sensor timings
            HitCalc = CalculateHit(measured_a, measured_b, measured_c, measured_d, 0, sound_speed_mmus);

            lbl_estX.Text = string.Format("X {0:f2}", HitCalc.X);
            lbl_estY.Text = string.Format("Y {0:f2}", HitCalc.Y);

            picCanvas.Refresh();
        }




        private PointF CalculateHit(double time_a, double time_b, double time_c, double time_d, double estimate_d, double sound_speed_mmus, int iteration = 0)
        {
            double min_time = 9999;

            double otime_a = time_a;
            double otime_b = time_b;
            double otime_c = time_c;
            double otime_d = time_d;

            string corner = "";

            iteration++;

            //Find which corner detected first (0 delay), make calculations relative to that corner
            if (time_a != 0)
                min_time = Math.Min(min_time, time_a);
            else
                corner = "A";

            if (time_b != 0)
                min_time = Math.Min(min_time, time_b);
            else
                corner = "B";

            if (time_c != 0)
                min_time = Math.Min(min_time, time_c);
            else
                corner = "C";

            if (time_d != 0)
                min_time = Math.Min(min_time, time_d);
            else
                corner = "D";

            //Convert target size to us based on the speed of sound
            double target_time = picCanvas.Width / sound_speed_mmus;
            double target_time2 = Math.Pow(target_time, 2);

            //If estimate = 0 - Estimate a value for the time delay of the first corner above
            if (estimate_d == 0)
                estimate_d = (target_time - min_time)+1 / 2;

            lbl_F.Text = string.Format("F {0:f2}", estimate_d);

            //Calculate angle for each corner using the estimated delay

            //The estimated delay is the measured delay for each sensor plus the estimated delay for the unknown
            //The unknown sensor will be zero here, so will just equal the estimated delay

            time_a += estimate_d;
            time_b += estimate_d;
            time_c += estimate_d;
            time_d += estimate_d;

            //A-D
            double AD_Angle = Math.Acos((Math.Pow(time_a, 2) + target_time2 - Math.Pow(time_d,2)) / (2 * time_a * target_time));

            double a = (Math.Pow(time_a, 2) + target_time2 - Math.Pow(time_d, 2));
            double b = (2 * time_a * target_time);

            if (a > b)
                AD_Angle = 0;

            double AD_Cos = Math.Cos(AD_Angle) * time_a;
            double AD_Sin = Math.Sin(AD_Angle) * time_a;

            //D-C
            double DC_Angle = Math.Acos((Math.Pow(time_d, 2) + target_time2 - Math.Pow(time_c, 2)) / (2 * time_d * target_time));

            if (double.IsNaN(DC_Angle))
                DC_Angle = 0;

            double DC_Cos = Math.Cos(DC_Angle) * time_d;
            double DC_Sin = Math.Sin(DC_Angle) * time_d;

            //C-B
            double CB_Angle = Math.Acos((Math.Pow(time_c, 2) + target_time2 - Math.Pow(time_b, 2)) / (2 * time_c * target_time));

            if (double.IsNaN(CB_Angle))
                CB_Angle = 0;

            double CB_Cos = Math.Cos(CB_Angle) * time_c;
            double CB_Sin = Math.Sin(CB_Angle) * time_c;

            //B-A
            double BA_Angle = Math.Acos((Math.Pow(time_b, 2) + target_time2 - Math.Pow(time_a, 2)) / (2 * time_b * target_time));

            if (double.IsNaN(BA_Angle))
                BA_Angle = 0;

            double BA_Cos = Math.Cos(BA_Angle) * time_b;
            double BA_Sin = Math.Sin(BA_Angle) * time_b;

            //Convert the Sin/Cos to XY postions based on their coordinates
            double hit_A_x_us = 0.0 + AD_Sin;
            double hit_A_y_us = 0.0 + AD_Cos;

            double hit_B_x_us = target_time - BA_Cos;
            double hit_B_y_us = 0.0 + BA_Sin;

            double hit_C_x_us = target_time - CB_Sin;
            double hit_C_y_us = target_time - CB_Cos;

            double hit_D_x_us = 0.0 + DC_Cos;
            double hit_D_y_us = target_time - DC_Sin;

            HitA = new Point(Convert.ToInt32(hit_A_x_us * sound_speed_mmus), Convert.ToInt32(hit_A_y_us * sound_speed_mmus));
            HitB = new Point(Convert.ToInt32(hit_B_x_us * sound_speed_mmus), Convert.ToInt32(hit_B_y_us * sound_speed_mmus));
            HitC = new Point(Convert.ToInt32(hit_C_x_us * sound_speed_mmus), Convert.ToInt32(hit_C_y_us * sound_speed_mmus));
            HitD = new Point(Convert.ToInt32(hit_D_x_us * sound_speed_mmus), Convert.ToInt32(hit_D_y_us * sound_speed_mmus));

            //Average the resultant X,Y positions to get the calculated hit
            PointF CalcHit = new PointF(Convert.ToSingle(((hit_A_x_us + hit_B_x_us + hit_C_x_us + hit_D_x_us)*sound_speed_mmus) / 4.0), 
                Convert.ToSingle(((hit_A_y_us + hit_B_y_us + hit_C_y_us + hit_D_y_us)*sound_speed_mmus) / 4.0));

            //Calculate the new hypotenuse for the unknown corner
            double new_estimate = 0;

            switch( corner )
            {
                case "A":
                    new_estimate = Math.Sqrt(Math.Pow(CalcHit.X, 2) + Math.Pow(CalcHit.Y, 2));
                    otime_a = 0;
                    break;

                case "B":
                    new_estimate = Math.Sqrt(Math.Pow(picCanvas.Width-CalcHit.X, 2) + Math.Pow(CalcHit.Y, 2));
                    otime_b = 0;
                    break;

                case "C":
                    new_estimate = Math.Sqrt(Math.Pow(picCanvas.Width - CalcHit.X, 2) + Math.Pow(picCanvas.Width - CalcHit.Y, 2));
                    otime_c = 0;
                    break;

                case "D":
                    new_estimate = Math.Sqrt(Math.Pow(CalcHit.X, 2) + Math.Pow(picCanvas.Width - CalcHit.Y, 2));
                    otime_d = 0;
                    break;
            }     

            new_estimate = new_estimate / sound_speed_mmus;

            lbl_newH.Text = string.Format("N {0:f2}", new_estimate);

            //return CalcHit;

            // - If delta is lower than threshold - return the position
            // - If delta is greater than threshold - retry with the new estimate

            if (Math.Abs(estimate_d - new_estimate) < 0.01)
            {
                lbl_iteration.Text = iteration.ToString();
                return CalcHit;
            }
            else
                return CalculateHit(otime_a, otime_b, otime_c, otime_d, new_estimate, sound_speed_mmus, iteration);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}