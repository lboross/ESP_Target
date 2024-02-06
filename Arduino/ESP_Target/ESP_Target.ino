;/*----------------------------------------------------------------
 * 
 * ESP Target        
 * 
 * ESP32 Based electronic target for supersonic ammunition using
 * minimal hardware required
 * 
 *-------------------------------------------------------------*/

#include "ESP_Target.h"

void setup() {
  
  Serial.begin(115200);

  //Execute a test of the calculate function
  float target_width = 400; //Target width (distance between sensors) in mm

  float target_time = 400/0.343; //Time delay between sensors based on the speed of sound

  //Example hit at 135, 225
  point_f hit = calculateHit(target_time, 120.619, 369.138, 281.483, 0.0, 0, 0 );

  Serial.printf( "Raw Coordinates x: %2f y: %2f\n", hit.x, hit.y );

  //Convert delay back to coordinates
  hit.x = hit.x * 0.343;
  hit.y = hit.y * 0.343;

  Serial.printf( "Physical Coordinates x: %2f y: %2f\n", hit.x, hit.y );

}

void loop() {
  // put your main code here, to run repeatedly:

}
