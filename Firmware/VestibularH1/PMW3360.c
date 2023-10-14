#include "PMW3360.h"
#include "spi.h"
#include "app_ios_and_regs.h"

#define F_CPU 32000000
#include <util/delay.h>

uint8_t productID;
uint8_t invProductID;
uint8_t SromSignature;

bool optical_tracking_initialize_pwm3360_0(void)
{
	/* Power up and reset */
	optical_tracking_write_register_pmw3360_0(REG_Power_Up_Reset, 0x5A);	// Reset
	_delay_ms(100);
	
	/* Check if the right IC is present */
	uint8_t productID = optical_tracking_read_register_pwm3360_0(REG_Product_ID);
	uint8_t invProductID = optical_tracking_read_register_pwm3360_0(REG_Inverse_Product_ID);
	
	if (productID != 0x47 || invProductID != 0xB8)
		return false;
	
	/* Read the data registers */
	optical_tracking_read_register_pwm3360_0(REG_Motion);
	optical_tracking_read_register_pwm3360_0(REG_Delta_X_L);
	optical_tracking_read_register_pwm3360_0(REG_Delta_X_H);
	optical_tracking_read_register_pwm3360_0(REG_Delta_Y_L);
	optical_tracking_read_register_pwm3360_0(REG_Delta_Y_H);
	
	// Upload firmware
	
	_delay_ms(10);
	
	return true;
}


bool optical_tracking_initialize_pwm3360_1(void)
{
	/* Power up and reset */
	optical_tracking_write_register_pmw3360_1(REG_Power_Up_Reset, 0x5A);	// Reset
	_delay_ms(100);
	
	/* Check if the right IC is present */
	uint8_t productID = optical_tracking_read_register_pwm3360_1(REG_Product_ID);
	uint8_t invProductID = optical_tracking_read_register_pwm3360_1(REG_Inverse_Product_ID);
	
	if (productID != 0x47 || invProductID != 0xB8)
		return false;
	
	/* Read the data registers */
	optical_tracking_read_register_pwm3360_1(REG_Motion);
	optical_tracking_read_register_pwm3360_1(REG_Delta_X_L);
	optical_tracking_read_register_pwm3360_1(REG_Delta_X_H);
	optical_tracking_read_register_pwm3360_1(REG_Delta_Y_L);
	optical_tracking_read_register_pwm3360_1(REG_Delta_Y_H);
	
	// Upload firmware
	
	_delay_ms(10);
	
	return true;
}

uint8_t optical_tracking_read_register_pwm3360_0(uint8_t address)
{
	address &= ~0x80;

	spi_start_flow0();
	_delay_us(1);
	_delay_us(10);
	spi_tx_byte_flow0(address);
	_delay_us(100);							// Increased to 100 microseconds
	uint8_t byte = spi_rx_byte_flow0();
	_delay_us(1);
	spi_stop_flow0();
	
	_delay_us(19);								// Added this delay

	return byte;
}

uint8_t optical_tracking_read_register_pwm3360_1(uint8_t address)
{
	address &= ~0x80;

	spi_start_flow1();
	_delay_us(1);
	_delay_us(10);
	spi_tx_byte_flow1(address);
	_delay_us(100);							// Increased to 100 microseconds
	uint8_t byte = spi_rx_byte_flow1();
	_delay_us(1);
	spi_stop_flow1();
	
	_delay_us(19);								// Added this delay

	return byte;
}

void optical_tracking_write_register_pmw3360_0(uint8_t address, uint8_t byte)
{
	address |= 0x80;

	spi_start_flow0();
	_delay_us(1);
	_delay_us(10);
	spi_tx_byte_flow0(address);
	_delay_us(1);
	_delay_us(10);
	spi_tx_byte_flow0(byte);
	_delay_us(20);								// Increased to 20 microseconds
	spi_stop_flow0();
	
	_delay_us(100);							// Added this delay
}

void optical_tracking_write_register_pmw3360_1(uint8_t address, uint8_t byte)
{
	address |= 0x80;

	spi_start_flow1();
	_delay_us(1);
	_delay_us(10);
	spi_tx_byte_flow1(address);
	_delay_us(1);
	_delay_us(10);
	spi_tx_byte_flow1(byte);
	_delay_us(20);								// Increased to 20 microseconds
	spi_stop_flow1();
	
	_delay_us(100);							// Added this delay
}