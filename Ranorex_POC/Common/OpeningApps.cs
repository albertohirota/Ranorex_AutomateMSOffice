﻿/*
 * Created by Ranorex
 * User: alberto.hirota
 * Date: 11/6/2022
 * Time: 1:26 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using Ranorex;
using System.Diagnostics;
using System.IO;

namespace Ranorex_POC.Common
{
	/// <summary>
	/// Description of OpeningApps.
	/// </summary>
	public class OpeningApps
	{
		public static Ranorex_POCRepository repo = Ranorex_POCRepository.Instance;
		        
        /// <summary>
        /// Description: StartsExplorer in case it did not automatically open it.
        /// </summary>
        public static void StartExplorer()
        {
        	try
        	{
	        	Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
				Delay.Seconds(5);	        	
        	} catch (Exception e) {
        		Report.Error(e.Message);
        	}
        }
        
        public static void OpenApplication(string application)
        {
        	Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{LWin down}r{LWin up}'. Opening Run");
            Keyboard.Press("{LWin down}r{LWin up}");
            Delay.Milliseconds(500);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence: "+ application+" with focus on 'Run.OpenText'.", repo.Run.OpenTextInfo);
            repo.Run.OpenText.PressKeys(application);
            Delay.Milliseconds(200);

			Report.Log(ReportLevel.Info, "MouseClick", "Mouse click OK Button'.", repo.Run.ButtonOkInfo);
            repo.Run.ButtonOk.Click();
            Delay.Milliseconds(200);        
        }
	}
}