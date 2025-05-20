/*******************************************************************************************************************************************************
Copyright © Beijer Electronics, 2016 - 2021 
This software/documentation/information (below referred to as ‘the material’) is the property of Beijer Electronics. 
The holder or user has a non-exclusive right to use the material.
The holder is not allowed to distribute the material to anyone outside his/her organization except in cases where the material is 
part of a system that is supplied by the holder to his/her customer.
The material may only be used with products or software supplied by Beijer Electronics.

Beijer Electronics assumes no responsibility for any defects in the material, or for any consequences that might arise from the use of the material.
It is the responsibility of the holder to ensure that any systems, for whatever applications, which is based on or includes 
the material (whether in its entirety or in parts), meets the expected properties or functional requirements.

Beijer Electronics has no obligation to supply the holder with updated versions.

*********************************************************************************************************************************************************
Date:  2021-08-11
Responsible:
KSR
*********************************************************************************************************************************************************
 
Function:
detect whether USB or SD media are plugged into the device
********************************************************************************************************************************************************/


namespace Neo.ApplicationFramework.Generated
{
    using System.Windows.Forms;
    using System;
    using System.Drawing;
    using Neo.ApplicationFramework.Tools;
    using Neo.ApplicationFramework.Common.Graphics.Logic;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
    
	using System.IO;	
    
	public partial class SCM_USB_SD_Check
	{
		// Create new timer object, used for periodically port check.
		private Timer m_Timer = new Timer();
		
		void SCM_USB_SD_Check_Created(System.Object sender, System.EventArgs e)
		{
			m_Timer= new Timer();            
			m_Timer.Enabled = true;
			m_Timer.Interval = 1000; 		//ms - adjust time for cyclic check here.
			m_Timer.Tick += OnTimerTick;
		}

		// The code below is executed once every timer tick
		private void OnTimerTick(System.Object sender, System.EventArgs e)
		{	
			if(Directory.Exists("\\Hard Disk"))				// Check if USB key is connected
				Globals.Tags.USB_plugged_In.SetTag();		// Set tag if connected
			else
				Globals.Tags.USB_plugged_In.ResetTag();		// Reset tag if disconnected						
			
			if(Directory.Exists("\\Storage Card"))				// Check if SD key is connected
				Globals.Tags.SD_plugged_In.SetTag();		// Set tag if connected
			else
				Globals.Tags.SD_plugged_In.ResetTag();		// Reset tag if disconnected						
		}	
    }
}
