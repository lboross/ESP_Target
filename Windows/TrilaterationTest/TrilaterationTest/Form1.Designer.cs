namespace TrilaterationTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picCanvas = new PictureBox();
            label1 = new Label();
            tb_airTemp = new TextBox();
            lb_delay_a = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lb_soundSpeed = new Label();
            lb_delay_b = new Label();
            lb_delay_c = new Label();
            lb_delay_d = new Label();
            label2 = new Label();
            label8 = new Label();
            lb_delay_a_actual = new Label();
            lb_delay_a_measured = new Label();
            lb_delay_b_actual = new Label();
            lb_delay_b_measured = new Label();
            lb_delay_c_actual = new Label();
            lb_delay_c_measured = new Label();
            lb_delay_d_measured = new Label();
            lb_delay_d_actual = new Label();
            label9 = new Label();
            lb_hitX = new Label();
            lb_hitY = new Label();
            label10 = new Label();
            lbl_estX = new Label();
            lbl_estY = new Label();
            lbl_newH = new Label();
            lbl_F = new Label();
            label11 = new Label();
            lbl_iteration = new Label();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // picCanvas
            // 
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(29, 24);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(400, 400);
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            picCanvas.Paint += picCanvas_Paint;
            picCanvas.MouseClick += picCanvas_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(560, 24);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Air Temp *c";
            // 
            // tb_airTemp
            // 
            tb_airTemp.Location = new Point(643, 21);
            tb_airTemp.Name = "tb_airTemp";
            tb_airTemp.Size = new Size(100, 23);
            tb_airTemp.TabIndex = 2;
            tb_airTemp.Text = "25";
            // 
            // lb_delay_a
            // 
            lb_delay_a.AutoSize = true;
            lb_delay_a.Location = new Point(559, 95);
            lb_delay_a.Name = "lb_delay_a";
            lb_delay_a.Size = new Size(47, 15);
            lb_delay_a.TabIndex = 3;
            lb_delay_a.Text = "Delay A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 11);
            label3.Name = "label3";
            label3.Size = new Size(15, 15);
            label3.TabIndex = 4;
            label3.Text = "A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(438, 7);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 5;
            label4.Text = "B";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(439, 424);
            label5.Name = "label5";
            label5.Size = new Size(15, 15);
            label5.TabIndex = 6;
            label5.Text = "C";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 426);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 7;
            label6.Text = "D";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(559, 51);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 8;
            label7.Text = "Sound mm/us";
            // 
            // lb_soundSpeed
            // 
            lb_soundSpeed.AutoSize = true;
            lb_soundSpeed.Location = new Point(645, 50);
            lb_soundSpeed.Name = "lb_soundSpeed";
            lb_soundSpeed.Size = new Size(28, 15);
            lb_soundSpeed.TabIndex = 9;
            lb_soundSpeed.Text = "0.00";
            // 
            // lb_delay_b
            // 
            lb_delay_b.AutoSize = true;
            lb_delay_b.Location = new Point(559, 110);
            lb_delay_b.Name = "lb_delay_b";
            lb_delay_b.Size = new Size(46, 15);
            lb_delay_b.TabIndex = 10;
            lb_delay_b.Text = "Delay B";
            // 
            // lb_delay_c
            // 
            lb_delay_c.AutoSize = true;
            lb_delay_c.Location = new Point(559, 125);
            lb_delay_c.Name = "lb_delay_c";
            lb_delay_c.Size = new Size(47, 15);
            lb_delay_c.TabIndex = 11;
            lb_delay_c.Text = "Delay C";
            // 
            // lb_delay_d
            // 
            lb_delay_d.AutoSize = true;
            lb_delay_d.Location = new Point(559, 140);
            lb_delay_d.Name = "lb_delay_d";
            lb_delay_d.Size = new Size(47, 15);
            lb_delay_d.TabIndex = 12;
            lb_delay_d.Text = "Delay D";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(624, 79);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 13;
            label2.Text = "Actual";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(679, 79);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 14;
            label8.Text = "Measured";
            // 
            // lb_delay_a_actual
            // 
            lb_delay_a_actual.AutoSize = true;
            lb_delay_a_actual.Location = new Point(619, 96);
            lb_delay_a_actual.Name = "lb_delay_a_actual";
            lb_delay_a_actual.Size = new Size(13, 15);
            lb_delay_a_actual.TabIndex = 15;
            lb_delay_a_actual.Text = "0";
            // 
            // lb_delay_a_measured
            // 
            lb_delay_a_measured.AutoSize = true;
            lb_delay_a_measured.Location = new Point(679, 96);
            lb_delay_a_measured.Name = "lb_delay_a_measured";
            lb_delay_a_measured.Size = new Size(13, 15);
            lb_delay_a_measured.TabIndex = 16;
            lb_delay_a_measured.Text = "0";
            // 
            // lb_delay_b_actual
            // 
            lb_delay_b_actual.AutoSize = true;
            lb_delay_b_actual.Location = new Point(619, 111);
            lb_delay_b_actual.Name = "lb_delay_b_actual";
            lb_delay_b_actual.Size = new Size(13, 15);
            lb_delay_b_actual.TabIndex = 17;
            lb_delay_b_actual.Text = "0";
            // 
            // lb_delay_b_measured
            // 
            lb_delay_b_measured.AutoSize = true;
            lb_delay_b_measured.Location = new Point(679, 110);
            lb_delay_b_measured.Name = "lb_delay_b_measured";
            lb_delay_b_measured.Size = new Size(13, 15);
            lb_delay_b_measured.TabIndex = 18;
            lb_delay_b_measured.Text = "0";
            // 
            // lb_delay_c_actual
            // 
            lb_delay_c_actual.AutoSize = true;
            lb_delay_c_actual.Location = new Point(619, 125);
            lb_delay_c_actual.Name = "lb_delay_c_actual";
            lb_delay_c_actual.Size = new Size(13, 15);
            lb_delay_c_actual.TabIndex = 19;
            lb_delay_c_actual.Text = "0";
            // 
            // lb_delay_c_measured
            // 
            lb_delay_c_measured.AutoSize = true;
            lb_delay_c_measured.Location = new Point(679, 125);
            lb_delay_c_measured.Name = "lb_delay_c_measured";
            lb_delay_c_measured.Size = new Size(13, 15);
            lb_delay_c_measured.TabIndex = 20;
            lb_delay_c_measured.Text = "0";
            // 
            // lb_delay_d_measured
            // 
            lb_delay_d_measured.AutoSize = true;
            lb_delay_d_measured.Location = new Point(679, 140);
            lb_delay_d_measured.Name = "lb_delay_d_measured";
            lb_delay_d_measured.Size = new Size(13, 15);
            lb_delay_d_measured.TabIndex = 22;
            lb_delay_d_measured.Text = "0";
            // 
            // lb_delay_d_actual
            // 
            lb_delay_d_actual.AutoSize = true;
            lb_delay_d_actual.Location = new Point(619, 140);
            lb_delay_d_actual.Name = "lb_delay_d_actual";
            lb_delay_d_actual.Size = new Size(13, 15);
            lb_delay_d_actual.TabIndex = 21;
            lb_delay_d_actual.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(466, 32);
            label9.Name = "label9";
            label9.Size = new Size(25, 15);
            label9.TabIndex = 23;
            label9.Text = "HIT";
            // 
            // lb_hitX
            // 
            lb_hitX.AutoSize = true;
            lb_hitX.Location = new Point(466, 50);
            lb_hitX.Name = "lb_hitX";
            lb_hitX.Size = new Size(14, 15);
            lb_hitX.TabIndex = 24;
            lb_hitX.Text = "X";
            // 
            // lb_hitY
            // 
            lb_hitY.AutoSize = true;
            lb_hitY.Location = new Point(466, 65);
            lb_hitY.Name = "lb_hitY";
            lb_hitY.Size = new Size(14, 15);
            lb_hitY.TabIndex = 25;
            lb_hitY.Text = "Y";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(466, 95);
            label10.Name = "label10";
            label10.Size = new Size(52, 15);
            label10.TabIndex = 26;
            label10.Text = "Estimate";
            // 
            // lbl_estX
            // 
            lbl_estX.AutoSize = true;
            lbl_estX.Location = new Point(466, 111);
            lbl_estX.Name = "lbl_estX";
            lbl_estX.Size = new Size(14, 15);
            lbl_estX.TabIndex = 27;
            lbl_estX.Text = "X";
            // 
            // lbl_estY
            // 
            lbl_estY.AutoSize = true;
            lbl_estY.Location = new Point(466, 125);
            lbl_estY.Name = "lbl_estY";
            lbl_estY.Size = new Size(14, 15);
            lbl_estY.TabIndex = 28;
            lbl_estY.Text = "Y";
            // 
            // lbl_newH
            // 
            lbl_newH.AutoSize = true;
            lbl_newH.Location = new Point(466, 140);
            lbl_newH.Name = "lbl_newH";
            lbl_newH.Size = new Size(16, 15);
            lbl_newH.TabIndex = 29;
            lbl_newH.Text = "H";
            // 
            // lbl_F
            // 
            lbl_F.AutoSize = true;
            lbl_F.Location = new Point(466, 155);
            lbl_F.Name = "lbl_F";
            lbl_F.Size = new Size(13, 15);
            lbl_F.TabIndex = 30;
            lbl_F.Text = "F";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(559, 172);
            label11.Name = "label11";
            label11.Size = new Size(56, 15);
            label11.TabIndex = 31;
            label11.Text = "Iterations";
            // 
            // lbl_iteration
            // 
            lbl_iteration.AutoSize = true;
            lbl_iteration.Location = new Point(630, 171);
            lbl_iteration.Name = "lbl_iteration";
            lbl_iteration.Size = new Size(13, 15);
            lbl_iteration.TabIndex = 32;
            lbl_iteration.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_iteration);
            Controls.Add(label11);
            Controls.Add(lbl_F);
            Controls.Add(lbl_newH);
            Controls.Add(lbl_estY);
            Controls.Add(lbl_estX);
            Controls.Add(label10);
            Controls.Add(lb_hitY);
            Controls.Add(lb_hitX);
            Controls.Add(label9);
            Controls.Add(lb_delay_d_measured);
            Controls.Add(lb_delay_d_actual);
            Controls.Add(lb_delay_c_measured);
            Controls.Add(lb_delay_c_actual);
            Controls.Add(lb_delay_b_measured);
            Controls.Add(lb_delay_b_actual);
            Controls.Add(lb_delay_a_measured);
            Controls.Add(lb_delay_a_actual);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(lb_delay_d);
            Controls.Add(lb_delay_c);
            Controls.Add(lb_delay_b);
            Controls.Add(lb_soundSpeed);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lb_delay_a);
            Controls.Add(tb_airTemp);
            Controls.Add(label1);
            Controls.Add(picCanvas);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCanvas;
        private Label label1;
        private TextBox tb_airTemp;
        private Label lb_delay_a;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lb_soundSpeed;
        private Label lb_delay_b;
        private Label lb_delay_c;
        private Label lb_delay_d;
        private Label label2;
        private Label label8;
        private Label lb_delay_a_actual;
        private Label lb_delay_a_measured;
        private Label lb_delay_b_actual;
        private Label lb_delay_b_measured;
        private Label lb_delay_c_actual;
        private Label lb_delay_c_measured;
        private Label lb_delay_d_measured;
        private Label lb_delay_d_actual;
        private Label label9;
        private Label lb_hitX;
        private Label lb_hitY;
        private Label label10;
        private Label lbl_estX;
        private Label lbl_estY;
        private Label lbl_newH;
        private Label lbl_F;
        private Label label11;
        private Label lbl_iteration;
    }
}
