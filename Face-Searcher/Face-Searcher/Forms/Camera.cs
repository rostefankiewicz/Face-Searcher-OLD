using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Face_Searcher.Classes;

namespace Face_Searcher.Forms
{
    public partial class Camera : Form
    {
        //private clsCameraCollection tempCamCol;

        /// <summary>
        /// Load the page
        /// </summary>
        public Camera()
        {
            InitializeComponent();

            this.FormClosing += Form_FormClosing;

            //Load the controls
            this.loadControls(false);

            //Check the proper radio button
            this.Hide.Checked = !Program.blnShowStream;
            this.Show.Checked = Program.blnShowStream;
        }

        /// <summary>
        /// Since we already have all of the controls built, add them to the panel
        /// </summary>
        private void loadControls(bool runningOnly)
        {
            try
            {
                this.MainPanel.Controls.Clear();

                for (int i = 0; i < Program.tempCamCollection.camList.Count; i++)
                {
                    if (runningOnly && Program.tempCamCollection.camList[i].camControl.procID == 0)
                    {
                        //If we only want running cams and the cam is not running, then continue for
                        continue;
                    }

                    this.MainPanel.Controls.Add(Program.tempCamCollection.camList[i].camControl.camCheck);
                    this.MainPanel.Controls.Add(Program.tempCamCollection.camList[i].camControl.camLocal);
                    this.MainPanel.Controls.Add(Program.tempCamCollection.camList[i].camControl.camID);
                    this.MainPanel.Controls.Add(Program.tempCamCollection.camList[i].camControl.camRTSP);
                    this.MainPanel.Controls.Add(Program.tempCamCollection.camList[i].camControl.camAOI);
                    this.MainPanel.Controls.Add(Program.tempCamCollection.camList[i].camControl.camStart);
                }
            }
            catch (Exception x)
            {
                string hello = x.ToString();
            }
        }

        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to Exit Face-Searcher?\r\nAny unsaved changes will be lost.\r\nExit Face-Searcher?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                updateCamProcIDs();
                Program.exitApp();
            }
        }

        /// <summary>
        /// Close this form and go back to main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            bool blnGoBack = false;
            if (false) //if (hasChanges)
            {
                if (MessageBox.Show("If you leave this screen yout will lose any unsaved changes. Would you like to leave this screen", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    blnGoBack = true;
                }
            }
            else
            {
                blnGoBack = true;
            }

            if (blnGoBack)
            {
                //Update the procID of running cameras
                updateCamProcIDs();

                this.Dispose();
                Program.camCollection.refreshControls();
                Program.MP.Show();
            }
        }

        /// <summary>
        /// undo all changes and reload the panel view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoButton_Click(object sender, EventArgs e)
        {
            updateCamProcIDs();

            //Update the tempCamCol
            this.loadControls(false);
        }

        /// <summary>
        /// Loop through the camera list and only opt to display the cameras that are running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRunningButton_Click(object sender, EventArgs e)
        {
            bool showAll = false;
            if (this.ViewRunningButton.Text == "VIEW RUNNING")
            {
                showAll = true;
                this.ViewRunningButton.Text = "VIEW ALL";
            }
            else //VIEW ALL
            {
                showAll = false;
                this.ViewRunningButton.Text = "VIEW RUNNING";
            }
            FixLocations(showAll);
            this.loadControls(showAll);
        }
        
        /// <summary>
        /// Depending on if we want onyl running cameras or all cameras, adjust the location
        /// </summary>
        /// <param name="runningOnly"></param>
        private void FixLocations(bool runningOnly)
        {
            int count = 0;
            for (int i = 0; i < Program.tempCamCollection.camList.Count; i++)
            {
                if (Program.tempCamCollection.camList[i].camControl.procID == 0 && Program.tempCamCollection.camList[i].camProcID == 0 && runningOnly)
                {
                    //Camera is not running
                    continue;
                }
                else
                {
                    //camCheck.Location = new System.Drawing.Point(2, this.yPos);
                    Program.tempCamCollection.camList[i].camControl.camCheck.Location = new System.Drawing.Point(2, 33 * count);

                    //camLocal.Location = new System.Drawing.Point(59, this.yPos);
                    Program.tempCamCollection.camList[i].camControl.camLocal.Location = new System.Drawing.Point(59, 33 * count);

                    //camID.Location = new System.Drawing.Point(195, this.yPos);
                    Program.tempCamCollection.camList[i].camControl.camID.Location = new System.Drawing.Point(195, 33 * count);

                    //camRTSP.Location = new System.Drawing.Point(331, this.yPos);
                    Program.tempCamCollection.camList[i].camControl.camRTSP.Location = new System.Drawing.Point(331, 33 * count);

                    //camAOI.Location = new System.Drawing.Point(737, this.yPos);
                    Program.tempCamCollection.camList[i].camControl.camAOI.Location = new System.Drawing.Point(737, 33 * count);

                    //camStart.Location = new System.Drawing.Point(843, this.yPos);
                    Program.tempCamCollection.camList[i].camControl.camStart.Location = new System.Drawing.Point(843, 33 * count);

                    count++;
                }
            }
        }

        /// <summary>
        /// Adda new camera to the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            //Call the new camera function
            Program.tempCamCollection.newCam();

            //Refresh the display
            this.MainPanel.Controls.Clear();
            FixLocations(false);
            this.loadControls(false);
        }

        /// <summary>
        /// Copy the temp list to the live list. Save the live list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to save your changes?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.camCollection = Program.tempCamCollection;
                Program.camCollection.saveAllCams();
            }
        }

        /// <summary>
        /// If the camera is checked, prompt the user then remove the camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            bool userHasBeenPrompt = false;

            //Make sure that we go reverse when removing so we do not run into any index error
            for (int i = Program.tempCamCollection.camList.Count - 1; i >= 0; i--)
            {
                if (Program.tempCamCollection.camList[i].camControl.camCheck.Checked)
                {
                    if (userHasBeenPrompt)
                    {
                        //Kill the process if it was running
                        Program.killProcByID(Program.tempCamCollection.camList[i].camControl.procID);
                        Program.tempCamCollection.camList.RemoveAt(i);
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you would like to remove all selected cameras?\r\nRunning cameras that are removed will be stopped.", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            userHasBeenPrompt = true;
                            //Kill the process if it was running
                            Program.killProcByID(Program.tempCamCollection.camList[i].camControl.procID);
                            Program.tempCamCollection.camList.RemoveAt(i);
                        }
                        else
                        {
                            i = Program.tempCamCollection.camList.Count;
                            continue;
                        }
                    }
                }
            }

            //Loop through from 1 to camList.count and set the camNumbers
            for (int i = 0; i < Program.tempCamCollection.camList.Count; i++)
            {
                //Set the number now
                Program.tempCamCollection.camList[i].camNumber = i + 1;
                Program.tempCamCollection.camList[i].camControl.camCheck.Text = (i + 1).ToString();
            }

            //Refresh the display
            this.MainPanel.Controls.Clear();
            FixLocations(false);
            this.loadControls(false);
        }

        /// <summary>
        /// Make sure that we are updating the main collection with the procIDs as well
        /// </summary>
        private void updateCamProcIDs()
        {
            //Keep track of any cameras that we could not locate and had to be killed
            string camsWithoutHome = "";

            clsCameraCollection localCamCol = new clsCameraCollection();
            localCamCol = Program.camCollection.clone();

            //==========================Move to its own function later==========================
            //Check all cameras and see what ones can be saved
            for (int i = 0; i < Program.tempCamCollection.camList.Count; i++)
            {
                bool blnFound = false;
                int tempProcID = Program.tempCamCollection.camList[i].camControl.procID;
                for (int x = 0; x < localCamCol.camList.Count; x++)
                {
                    if (Program.tempCamCollection.camList[i].camLocation == localCamCol.camList[x].camLocation &&
                        Program.tempCamCollection.camList[i].camID == localCamCol.camList[x].camID &&
                        Program.tempCamCollection.camList[i].camRTSP == localCamCol.camList[x].camRTSP)
                    {
                        //We found a matching camera. Update the procID
                        blnFound = true;
                        localCamCol.camList[x].camProcID = tempProcID;
                        localCamCol.camList[x].camControl.procID = tempProcID;
                        localCamCol.camList[x].camControl.camStart.Text = "STOP";
                        localCamCol.camList[x].camControl.camStart.BackColor = Color.Red;
                    }
                }

                if (!blnFound && tempProcID != 0)
                {
                    //If the camera was not found in the old collection, kill it and add it to the 
                    camsWithoutHome += Program.tempCamCollection.camList[i].camID + "\r\n";
                    Program.killProcByID(tempProcID);
                }
            }

            if (camsWithoutHome.Trim() != "")
            {
                //If any unkown cameras were found. Let the user know
                MessageBox.Show("The following cameras could not be found in the main collection.\r\n\r\n" + camsWithoutHome + "\r\nThe cameras have been stopped.", "", MessageBoxButtons.OK);
            }

            Program.camCollection = localCamCol;
            Program.tempCamCollection = localCamCol.clone();
        }

        /// <summary>
        /// Although we have 2 radio buttons, we only need to check if one is switched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_CheckedChanged(object sender, EventArgs e)
        {
            Program.blnShowStream = !this.Hide.Checked;
        }

        /// <summary>
        /// What to do on application close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure that you would like to Exit Face-Searcher?\r\nAny unsaved changes will be lost.\r\nExit Face-Searcher?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.exitApp();
                }
            }
        }

        /// <summary>
        /// Convert a threads request to something that can be used on this form
        /// </summary>
        public void DoSomething()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(loadAllControl));
            }
            else
            {
                // Do Something
                loadAllControl();
            }
        }

        /// <summary>
        /// Update the form based on outside threads
        /// </summary>
        private void loadAllControl()
        {
            for (int i = 0; i < Program.tempCamCollection.camList.Count; i++)
            {
                var cam = Program.tempCamCollection.camList[i];
                if (cam.camProcID == 0 && cam.camControl.procID == 0 && cam.camControl.camStart.Text == "STOP")
                {
                    cam.camControl.camStart.Text = "START";
                    cam.camControl.camStart.BackColor = Color.MediumSeaGreen;
                }
            }
            loadControls(false);
        }
    }
}
