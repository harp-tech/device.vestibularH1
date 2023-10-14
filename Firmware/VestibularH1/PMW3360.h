#ifndef _PMW3360_H_
#define _PMW3360_H_
#include "cpu.h"
#include "MotionHeader.h"


#define REG_Product_ID  0x00
#define REG_Revision_ID 0x01
#define REG_Motion  0x02
#define REG_Delta_X_L 0x03
#define REG_Delta_X_H 0x04
#define REG_Delta_Y_L 0x05
#define REG_Delta_Y_H 0x06
#define REG_SQUAL 0x07
#define REG_Raw_Data_Sum  0x08
#define REG_Maximum_Raw_data  0x09
#define REG_Minimum_Raw_data  0x0A
#define REG_Shutter_Lower 0x0B
#define REG_Shutter_Upper 0x0C
#define REG_Control 0x0D
#define REG_Config1 0x0F
#define REG_Config2 0x10
#define REG_Angle_Tune  0x11
#define REG_Frame_Capture 0x12
#define REG_SROM_Enable 0x13
#define REG_Run_Downshift 0x14
#define REG_Rest1_Rate_Lower  0x15
#define REG_Rest1_Rate_Upper  0x16
#define REG_Rest1_Downshift 0x17
#define REG_Rest2_Rate_Lower  0x18
#define REG_Rest2_Rate_Upper  0x19
#define REG_Rest2_Downshift 0x1A
#define REG_Rest3_Rate_Lower  0x1B
#define REG_Rest3_Rate_Upper  0x1C
#define REG_Observation 0x24
#define REG_Data_Out_Lower  0x25
#define REG_Data_Out_Upper  0x26
#define REG_Raw_Data_Dump 0x29
#define REG_SROM_ID 0x2A
#define REG_Min_SQ_Run  0x2B
#define REG_Raw_Data_Threshold  0x2C
#define REG_Config5 0x2F
#define REG_Power_Up_Reset  0x3A
#define REG_Shutdown  0x3B
#define REG_Inverse_Product_ID  0x3F
#define REG_LiftCutoff_Tune3  0x41
#define REG_Angle_Snap  0x42
#define REG_LiftCutoff_Tune1  0x4A
#define REG_Motion_Burst  0x50
#define REG_LiftCutoff_Tune_Timeout 0x58
#define REG_LiftCutoff_Tune_Min_Length  0x5A
#define REG_SROM_Load_Burst 0x62
#define REG_Lift_Config 0x63
#define REG_Raw_Data_Burst  0x64
#define REG_LiftCutoff_Tune2  0x65


bool optical_tracking_initialize_pwm3360_0(void);
bool optical_tracking_initialize_pwm3360_1(void);

void upload_the_firmware_pmw3360_0(void);
void upload_the_firmware_pmw3360_1(void);

uint8_t check_signatures_pmw3360_0(bool check_srom);
uint8_t check_signatures_pmw3360_1(bool check_srom);

void set_cpi_pmw3360_0 (uint32_t cpi);
void set_cpi_pmw3360_1 (uint32_t cpi);
uint16_t get_cpi_pmw3360_0 (void);
uint16_t get_cpi_pmw3360_1 (void);

void optical_tracking_read_motion_optimized_pmw3360(Motion motion_flow0[], Motion motion_flow1[]);

uint8_t optical_tracking_read_register_pwm3360_0(uint8_t address);
uint8_t optical_tracking_read_register_pwm3360_1(uint8_t address);
void optical_tracking_write_register_pmw3360_0(uint8_t address, uint8_t byte);
void optical_tracking_write_register_pmw3360_1(uint8_t address, uint8_t byte);

#endif /* _PMW3360_H_ */