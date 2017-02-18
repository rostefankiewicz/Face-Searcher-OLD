using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Face_Searcher.Forms;
using System.IO;
using System.Diagnostics;

namespace Face_Searcher.Classes
{
    class clsCameraControls
    {
        //make sure that we save this becaue the x value will be hardcoded but this will change from cam to cam
        public int yPos = 0;
        public int parentCamNum = 0;
        public int procID = 0;
        public CheckBox camCheck = new CheckBox();
        public TextBox camLocal = new TextBox();
        public TextBox camID = new TextBox();
        public TextBox camRTSP = new TextBox();
        public Button camAOI = new Button();
        public Button camStart = new Button();
        //public Button camViewStream = new Button();
        public clsDefaultAOI camAOISetting = new clsDefaultAOI();
        public System.Diagnostics.Process currProc = new System.Diagnostics.Process();

        /// <summary>
        /// Take the camera details class and build our controls based on that info
        /// </summary>
        /// <param name="CD"></param>
        public void loadCamControl(clsCameraDetails CD)
        {
            //This will be the height size * CD.CamNum - 1
            this.yPos = 33 * (CD.camNumber - 1);
            this.parentCamNum = CD.camNumber;
            camAOISetting = CD.camAOI;

            //Do I need to set names? Everything should refer to a collection
            camCheck.Text = CD.camNumber.ToString();
            camCheck.Size = new System.Drawing.Size(50, 26);
            camCheck.Location = new System.Drawing.Point(2, this.yPos);
            camCheck.Checked = false;
            camCheck.Font =  new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            camLocal.Text = CD.camLocation;
            camLocal.Size = new System.Drawing.Size(130, 27);
            camLocal.Location = new System.Drawing.Point(59, this.yPos);
            camLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            camID.Text = CD.camID;
            camID.Size = new System.Drawing.Size(130, 27);
            camID.Location = new System.Drawing.Point(195, this.yPos);
            camID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            camRTSP.Text = CD.camRTSP;
            camRTSP.Size = new System.Drawing.Size(400, 27);
            camRTSP.Location = new System.Drawing.Point(331, this.yPos);
            camRTSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            camAOI.Text = "Cam AOI";
            camAOI.Size = new System.Drawing.Size(100, 27);
            camAOI.Location = new System.Drawing.Point(737, this.yPos);
            camAOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            camAOI.UseVisualStyleBackColor = true;
            camAOI.Click += new EventHandler(this.camAOI_Click);

            camStart.Size = new System.Drawing.Size(100, 27);
            camStart.Location = new System.Drawing.Point(843, this.yPos);
            camStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (CD.camProcID != 0)
            {
                camStart.Text = "STOP";
                camStart.BackColor = System.Drawing.Color.Red;
                camStart.Click += new EventHandler(this.camStart_Click);
            }
            else
            {
                camStart.Text = "START";
                camStart.BackColor = System.Drawing.Color.MediumSeaGreen;
                camStart.Click += new EventHandler(this.camStart_Click);
            }
        }

        /// <summary>
        /// What to do when you press the Cam AOI button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void camAOI_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("CAM AOI: " + this.parentCamNum, "AOI", MessageBoxButtons.OK);
                IndivAOIPopup aoi = new IndivAOIPopup();
                aoi.aoi = camAOISetting;
                aoi.loadText();
                aoi.Show();
            }
            catch
            {
                //Do Nothing
            }
        }

        /// <summary>
        /// What to do what you click the start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void camStart_Click(object sender, EventArgs e)
        {
            try
            {
                string camAction = this.camStart.Text;

                this.camStart.Text = "...";
                this.camStart.BackColor = Color.Yellow;
                this.camStart.Refresh();

                if (camAction == "START")
                {
                    //Save the cam RTSP to the ATIPS file so Aureus_Tracking knows what cam to start
                    Program.writeToFile(Program.ATIPS, this.camRTSP.Text);

                    //Save the cameras AOI settings to the correct file now
                    string aoi = "";
                    aoi = this.camAOISetting.top + "," +
                        this.camAOISetting.left + "," +
                        this.camAOISetting.height + "," +
                        this.camAOISetting.width + "," +
                        this.camAOISetting.minHead + "," +
                        this.camAOISetting.maxHead;

                    //update the control settings as well
                    string controlSettings = "";
                    controlSettings = this.camAOISetting.top + "\r\n" +
                        this.camAOISetting.left + "\r\n" +
                        this.camAOISetting.height + "\r\n" +
                        this.camAOISetting.width + "\r\n" +
                        this.camAOISetting.minHead + "\r\n" +
                        this.camAOISetting.maxHead;

                    //If the current AOI is already in the dictionary,remove it before adding it
                    if (Program.AOIContent.ContainsKey(this.camRTSP.Text))
                    {
                        Program.AOIContent.Remove(this.camRTSP.Text);
                    }

                    //Add the value to the dictionary
                    Program.AOIContent.Add(this.camRTSP.Text, aoi);

                    //Save the AOI file
                    Program.saveAllAOI();

                    //Set the control settings to this cameras AOI settings
                    Program.writeToFile(Program.contentSettingsFile, controlSettings);

                    //Start the camera. Do not need to use another function since this is specific
                    Process proc = new Process();
                    proc.StartInfo.FileName = Program.AureusTracking;
                    proc.StartInfo.UseShellExecute = false;
                    if (Program.blnShowStream)
                    {
                        proc.StartInfo.RedirectStandardOutput = false;
                        proc.StartInfo.CreateNoWindow = false;
                    }
                    else
                    {
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.RedirectStandardError = true;
                        proc.StartInfo.CreateNoWindow = true;
                    }
                    //Start the process
                    proc.Start();
                    //Get the process ID to return
                    this.procID = proc.Id;

                    if (!Program.blnShowStream)
                    {
                        //Cannot do this if the camerra is running in the foreground because we do not have the stream
                        StreamReader SR = proc.StandardOutput;

                        bool exit = false;
                        bool failed = false;
                        string currLine = "START";
                        int exitCount = 0;
                        while (!exit)
                        {
                            if (proc.HasExited) { exit = true; failed = true; continue; }

                            var task = SR.ReadLineAsync();
                            if (!task.Wait(15000))
                            {
                                //Wait 10 seconds. If no response, exit with a failure message
                                failed = true;
                                exit = true;
                                continue;
                            }

                            currLine = task.Result;

                            //Check for a failure
                            if (currLine == null) { exit = true; failed = true; continue; }
                            if (currLine.Contains("TERMINATION")) { exit = true; failed = true; continue; }
                            if (currLine.Contains("TERMINATED")) { exit = true; failed = true; continue; }
                            if (currLine.Contains("FAILED")) { exit = true; failed = true; continue; }
                            //Check for a success
                            if (currLine.Contains("FRAME")) { exit = true; continue; }
                            //If we have reached line 100 for some reason,fail this out.
                            if (exitCount >= 100) { exit = true; failed = true; continue; }
                            exitCount++; //Increment the exit counter
                        }

                        if (failed)
                        {
                            Program.killProcByID(procID);
                            procID = 0;
                            MessageBox.Show("Your Camera has failed to start", "Failure", MessageBoxButtons.OK);
                        }
                        else
                        {
                            //Start the background worker
                            clsCameraMonitor CM = new clsCameraMonitor();
                            CM.camID = this.camID.Text;
                            CM.camLocation = this.camLocal.Text;
                            CM.camRTSP = this.camRTSP.Text;
                            CM.proc = proc;
                            //Declare the thread
                            System.Threading.Thread BG = new System.Threading.Thread(new System.Threading.ThreadStart(CM.startMonitor));
                            //Start the thread
                            BG.Start();
                            //Add the thread to the main collection
                            Program.threadList.Add(this.procID.ToString(), BG);
                            //Make sure that the parentProc is updated correctly
                            Program.updateProcIdByValues(this.camRTSP.Text, this.camLocal.Text, this.camID.Text, this.procID, false);
                        }
                    }
                        
                    
                    //Start the background process.

                    if (this.procID != 0)
                    {
                        //Set the button text and color
                        this.camStart.Text = "STOP";
                        this.camStart.BackColor = Color.Red;
                    }else
                    {
                        //Set the button text and color
                        this.camStart.Text = "START";
                        this.camStart.BackColor = Color.MediumSeaGreen;
                    }
                }
                else
                {
                    if (Program.threadList.ContainsKey(this.procID.ToString()))
                    {
                        //Kill and abort the thread
                        Program.threadList[this.procID.ToString()].Abort();
                        Program.threadList.Remove(this.procID.ToString());
                    }
                    //Stop the camera... Why is this part so simple
                    Program.killProcByID(this.procID);
                    //Set the procID to 0
                    this.procID = 0;
                    //Remove AOI settings from the dictinoary
                    Program.AOIContent.Remove(this.camRTSP.Text);
                    //Save the AOIs
                    Program.saveAllAOI();

                    //Set the button text and color
                    this.camStart.Text = "START";
                    this.camStart.BackColor = Color.MediumSeaGreen;
                }
                
                //Refresh the display
                this.camStart.Refresh();
            }
            catch (Exception x)
            {
                string hello = x.ToString();
            }
        }
    }
}
