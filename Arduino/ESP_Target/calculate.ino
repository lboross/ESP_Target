/* ----------------------------------------------------------------- \*
Calculate point of impact based on timing difference between sensors

Assumptions:

  Sensors arranged in a square box, sensor_width apart

  A = 0,0
  B = sensor_width,0
  C = sensor_width,sensor_width
  D = 0, sensor_width

  Example

  Shot hits the target at *

  A --------------- B
  |                 |
  |                 |
  |                 |
  |                 |
  |                 |
  |           *     |
  |                 |
  D --------------- C


C detects the shot first and resets the counter
D detects the shot next, delta time from C = 357.3us
B detects the shot next, delta time from C = 641.5us
A detects the shot last, delta time from C = 860.0us

The distance between sensors A-B is 400mm
The target_time is (400/0.343) us across

\* ----------------------------------------------------------------- */

#define THRESHOLD 0.01f
//#define DEBUG

//Calculate the coordinates of an impact based on time delay between sensors. 
//All units are time in us, this could actually be any arbitary unit as this should be converted back to XY outside of this function
//This assumes the first sensor to get triggered will have a clock of 0
// -- Inputs --
// target_time: Distance between sensors, measured in time delay us
// time_a: Delay measured for sensor A in us
// time_b: Delay measured for sensor B in us
// time_c: Delay measured for sensor C in us
// time_d: Delay measured for sensor D in us
// estimate: Estimated delay for the first sensor (time = 0) used to recursively find a result within the target threshold
// iteration: Current iteration number - Start at 0
//
// -- Returns -- 
// X,Y coordinates in base units
//
struct point_f calculateHit(double target_time, double time_a, double time_b, double time_c, double time_d, double estimate, int iteration)
{
  iteration++;

  #ifdef DEBUG
  Serial.printf( " ------ Iteration %2i ------ \n", iteration );
  Serial.printf( "Time A %2f\n", time_a );
  Serial.printf( "Time B %2f\n", time_b );
  Serial.printf( "Time C %2f\n", time_c );
  Serial.printf( "Time D %2f\n", time_d );
  #endif

  //Estimated times (factoring in the first sensor time)
  double est_a = 0, est_b = 0, est_c = 0, est_d = 0;

  double ae = 0, be = 0;

  //Store target_time squared
  double target_time_sq = sq(target_time);
  double min_time = 9999;

  //If estimate = 0 - Calculate a first estimate for the time delay of the first corner
  if( estimate == 0.0)
  {
    //Calculate the minimum time, not including the first detected sensor to form an estimate
    //The sensor with time=0 is the first sensor to detect the impact
    if( time_a != 0.0 )
      min_time = min( time_a, min_time);
    if( time_b != 0.0 )
      min_time = min( time_b, min_time);
    if( time_c != 0.0 )
      min_time = min( time_c, min_time);
    if( time_d != 0.0 )
      min_time = min( time_d, min_time);

    estimate = (target_time - min_time) / 2.0f;
  }  

  //The estimated delay for each sensor is the measured delay plus the estimated delay for the unknown
  est_a = time_a + estimate;
  est_b = time_b + estimate;
  est_c = time_c + estimate;
  est_d = time_d + estimate;

  #ifdef DEBUG
  Serial.printf( "Target Time %2f\n", target_time );
  Serial.printf( "Min Time    %2f\n", min_time );
  Serial.printf( "Estimate    %2f\n", estimate );
  Serial.printf( "Delay A %2f\n", est_a );
  Serial.printf( "Delay B %2f\n", est_b );
  Serial.printf( "Delay C %2f\n", est_c );
  Serial.printf( "Delay D %2f\n", est_d );
  #endif

  //Calculate the angle for each of the sensors, using the rule of cosines

  /*
                |-  ( A^2 + B^2 - C^2 ) -|
  Angle =  ACOS |------------------------|
	              |-      2 * A * B       -|
  */

  double angle_ad = 0, angle_ba = 0, angle_cb = 0, angle_dc = 0;

  //Angle A-D
  ae = (sq(est_a) + target_time_sq - sq(est_d));
  be = (2 * est_a * target_time);
  if( be > ae ) //Validate acos will return valid result
    angle_ad = acos( ae / be );

  //Angle B-A
  ae = (sq(est_b) + target_time_sq - sq(est_a));
  be = (2 * est_b * target_time);
  if( be > ae ) //Validate acos will return valid result
    angle_ba = acos( ae / be );

  //Angle C-B
  ae = (sq(est_c) + target_time_sq - sq(est_b));
  be = (2 * est_c * target_time);
  if( be > ae ) //Validate acos will return valid result
    angle_cb = acos( ae / be );

  //Angle D-C
  ae = (sq(est_d) + target_time_sq - sq(est_c));
  be = (2 * est_d * target_time);
  if( be > ae ) //Validate acos will return valid result
    angle_dc = acos( ae / be );

  #ifdef DEBUG
  Serial.printf( "Angle AD: %2f\n", angle_ad );
  Serial.printf( "Angle BA: %2f\n", angle_ba );
  Serial.printf( "Angle CB: %2f\n", angle_cb );
  Serial.printf( "Angle DC: %2f\n", angle_dc );
  #endif

  //Calculate the XY offset using sin and cos of the angle and the time delay (relative to sensor location)
  double a_x_us = sin(angle_ad) * est_a;
  double a_y_us = cos(angle_ad) * est_a;

  double b_x_us = target_time - cos(angle_ba) * est_b;
  double b_y_us = sin(angle_ba) * est_b;

  double c_x_us = target_time - sin(angle_cb) * est_c;
  double c_y_us = target_time - cos(angle_cb) * est_c;

  double d_x_us = cos(angle_dc) * est_d;
  double d_y_us = target_time - sin(angle_dc) * est_d;

  //Average the XY from each of the corners to get the estimated impact position
  double average_x = (a_x_us+b_x_us+c_x_us+d_x_us)/4.0f;
  double average_y = (a_y_us+b_y_us+c_y_us+d_y_us)/4.0f;

  double new_estimate = 0;

  //Calculate a new estimated delay based on the estimated impact
  if( time_a == 0 )
    new_estimate = sqrt( sq(average_x) + sq(average_y));
  if( time_b == 0 )
    new_estimate = sqrt( sq(target_time - average_x) + sq(average_y));
  if( time_c == 0 )
    new_estimate = sqrt( sq(target_time - average_x) + sq(target_time - average_y));
  if( time_d == 0 )
    new_estimate = sqrt( sq(average_x) + sq(target_time - average_y));

  //New calculated impact position
  struct point_f calculated;
  calculated.x = average_x;
  calculated.y = average_y;

  #ifdef DEBUG
  Serial.printf("New Estimate: %2f\n", new_estimate);
  Serial.printf("Error: %2f\n", new_estimate - estimate);
  #endif

  if( abs(estimate - new_estimate) < THRESHOLD || iteration > 6 )
    //If our estimate is within the threshold, return the calculated location
    return calculated;
  else
    //Re-run the calculation with the new estimate
    return calculateHit(target_time, time_a, time_b, time_c, time_d, new_estimate, iteration);

}


