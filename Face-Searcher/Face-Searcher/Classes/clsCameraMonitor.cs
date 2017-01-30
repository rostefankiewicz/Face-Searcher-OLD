using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Face_Searcher.Forms;

namespace Face_Searcher.Classes
{
    class clsCameraMonitor
    {
        public Process proc;
        public string camLocation = "";
        public string camID = "";
        public string camRTSP = "";
        
         public void startMonitor()
        {
            try
            {
                StreamReader SR = proc.StandardOutput;
                bool blnFailed = false;
                string currLine = "";
                string prevLine = "";
                int dupLineCount = 0;
                while (!proc.HasExited && !blnFailed)
                {
                    if (proc.HasExited) { blnFailed = true; continue; }

                    var task = SR.ReadLineAsync();
                    if(!task.Wait(10000))
                    {
                        //Wait 10 seconds. If no response, exit
                        blnFailed = true;
                        continue;
                    }

                    currLine = task.Result;

                    //Check for a failure
                    if (currLine == null) { blnFailed = true; continue; }
                    if (currLine.Contains("TERMINATION")) { blnFailed = true; continue; }
                    if (currLine.Contains("TERMINATED")) { blnFailed = true; continue; }
                    if (currLine.Contains("FAILED")) { blnFailed = true; continue; }
                    if (prevLine == currLine) { dupLineCount++; }
                    //if (dupLineCount >= 5) { blnFailed = true; continue; }
                    prevLine = currLine;
                }

                if (blnFailed)
                {
                    Program.killProcByID(proc.Id);
                    Program.sendEmail(camRTSP);
                    Program.updateProcIdByValues(camRTSP, camLocation, camID, 0, true, true);
                    MessageBox.Show("Camera " + this.camRTSP + " has failed. Your contact has been notified.", "Camera Failed!", MessageBoxButtons.OK);
                    //Camera.doThis();
                    System.Threading.Thread.CurrentThread.Abort();
                }
            }
            catch (Exception x)
            { 
                string hello = x.ToString();
            }
        }
    }
}
