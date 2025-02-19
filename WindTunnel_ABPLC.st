/* 
 * Tag setup:
 *
 * Internal Variables:
 * Output227 : REAL
 * Output454 : REAL
 * fullScale : INT
 * GAIN : INT
 * GRAMFORCETONEWTONS : REAL
 * EXCITATIONVOLTAGE : INT
 * DRAGSENSOR : INT
 * LIFTSENSOR : INT
 *
 * External Module Variables:
 * Analog In module 1769-IF4:
 * Strain : INT
 *
 */

/* Constants */
GAIN := 2;
GRAMFORCETONEWTONS := 0.00980665;
EXCITATIONVOLTAGE := 12;
DRAGSENSOR := 227;
LIFTSENSOR := 454;
fullScale [:=] GAIN * EXCITATIONVOLTAGE;

/*
 * Drag Sensor
 */
output227 [:=] (Strain / fullScale) * DRAGSENSOR * GRAMFORCETONEWTONS;

/*
 * Lift Sensor
 */

output454 [:=] (Strain / fullScale) * LIFTSENSOR * GRAMFORCETONEWTONS;

