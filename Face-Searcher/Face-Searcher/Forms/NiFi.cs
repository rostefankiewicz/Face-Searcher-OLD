using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Face_Searcher.Forms
{
    public partial class NiFi : Form
    {
        /// <summary>
        /// Load the page
        /// </summary>
        public NiFi()
        {
            InitializeComponent();

            this.FormClosing += Form_FormClosing;

            //This process closes when it is done. It does not stay running according to our program.
            //Check if the process is still running or not
            if (Program.nifiRunning)
            {
                if (checkNifiStatus())
                {
                    //Process is still running. Update everything that we need to
                    startNifiButton.Text = "STOP";
                    startNifiButton.BackColor = Color.Red;
                    startNifiButton.Refresh();
                }
            }

            //Check if the CameraPreProcessor process was running. If it is, then update the start button to say stop and be red
            if (Program.CamPreProcID != 0)
            {
                //Check if the process is still running or not
                if (Program.checkProcStatusByID(Program.CamPreProcID))
                {
                    //Process is still running. Update everything that we need to
                    startCamPreProcButton.Text = "STOP";
                    startCamPreProcButton.BackColor = Color.Red;
                    startCamPreProcButton.Refresh();
                }
                else
                {
                    //Not running anymore. Clear the variable and do nothing else
                    Program.CamPreProcID = 0;
                }
                   
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
            this.Dispose();
            Program.MP.Show();
        }

        /// <summary>
        /// Start/Stop the Nifi executable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startNifiButton_Click(object sender, EventArgs e)
        {
            if (startNifiButton.Text == "START")
            {
                //Display ... as yellow meaning that this is processing
                startNifiButton.Text = "...";
                startNifiButton.BackColor = Color.Yellow;
                startNifiButton.Refresh();

                //Start the NiFi application
                int procID = 0;
                procID = Program.startBackgroundProc(@"C:\CyberExtruder\NiFi\bin\run-nifi.bat", @"C:\CyberExtruder\NiFi\bin", true, false);
                if (procID != 0)
                {
                    //Make sure that we save the proc ID
                    //Program.NiFiProcID = procID;
                    Program.nifiRunning = true;
                    //Process is now running. Update everything that we need to
                    startNifiButton.Text = "STOP";
                    startNifiButton.BackColor = Color.Red;
                    startNifiButton.Refresh();
                }
                else
                {
                    //Warn the user that this failed to run for some reason
                    MessageBox.Show("Failed to start NiFi Interface", "Error!", MessageBoxButtons.OK);
                    startNifiButton.Text = "START";
                    startNifiButton.BackColor = Color.MediumSeaGreen;
                    startNifiButton.Refresh();
                }
            }
            else
            {
                //Display ... as yellow meaning that this is processing
                startNifiButton.Text = "...";
                startNifiButton.BackColor = Color.Yellow;
                startNifiButton.Refresh();

                //Stop the NiFi application
                int procID = 0;
                procID = Program.startBackgroundProc(@"C:\CyberExtruder\NiFi\bin\stop-nifi.bat", @"C:\CyberExtruder\NiFi\bin", true, true);

                //Make sure that we save the proc ID
                //Program.NiFiProcID = 0;
                Program.nifiRunning = false;
                //Process is now running. Update everything that we need to
                startNifiButton.Text = "START";
                startNifiButton.BackColor = Color.MediumSeaGreen;
                startNifiButton.Refresh();
            }
        }

        /// <summary>
        /// Open the NiFi web interface. This does not handle closing because it is a webpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NifiWebButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Open the default browser and go to the NiFi link
                System.Diagnostics.Process.Start("http://localhost:8080/nifi");
            }catch
            {
                //Warn the user that this failed to run for some reason
                MessageBox.Show("Failed to start NiFi Web Interface", "Error!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Start/Stop the Camera Pre-Processor executable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startCamPreProcButton_Click(object sender, EventArgs e)
        {
            if (startCamPreProcButton.Text == "START")
            {
                //Display ... as yellow meaning that this is processing
                startCamPreProcButton.Text = "...";
                startCamPreProcButton.BackColor = Color.Yellow;
                startCamPreProcButton.Refresh();

                //Start CamPreProc
                int procID = 0;
                //"Aureus\AureusHelper\Debug\AureusHelper.exe"
                procID = Program.startBackgroundProc(@"C:\CyberExtruder\Aureus\AureusHelper\Debug\AureusHelper.exe", "", true, false);

                if (procID != 0)
                {
                    //Make sure that we save the proc ID
                    Program.CamPreProcID = procID;
                    //Process is now running. Update everything that we need to
                    startCamPreProcButton.Text = "STOP";
                    startCamPreProcButton.BackColor = Color.Red;
                }
                else
                {
                    //Warn the user that this failed to run for some reason
                    MessageBox.Show("Failed to start the Camera Pre-Processor", "Error!", MessageBoxButtons.OK);

                    //Set the start button back up
                    startCamPreProcButton.Text = "START";
                    startCamPreProcButton.BackColor = Color.MediumSeaGreen;
                }
            }
            else
            {
                //Display ... as yellow meaning that this is processing
                startCamPreProcButton.Text = "...";
                startCamPreProcButton.BackColor = Color.Yellow;
                startCamPreProcButton.Refresh();

                if (Program.CamPreProcID != 0)
                {
                    Program.killProcByID(Program.CamPreProcID);
                }
                else
                {
                    //Warn the user that this failed to run for some reason
                    MessageBox.Show("The Camera Pre-Processor has already been stopped.", "Warning!", MessageBoxButtons.OK);
                }
                //Set the start button back up
                startCamPreProcButton.Text = "START";
                startCamPreProcButton.BackColor = Color.MediumSeaGreen;
                //Make sure that this is cleared out
                Program.CamPreProcID = 0;
            }
            startCamPreProcButton.Refresh();
        }

        /// <summary>
        /// Check if Nifi is still running on our computer or not
        /// </summary>
        /// <returns></returns>
        private bool checkNifiStatus()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\CyberExtruder\NiFi\bin\status-nifi.bat";
            proc.StartInfo.UseShellExecute = false;
            //Make sure to hide the window
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;

            //Add the working directory
            //This needs to be done for bat files apparently
            proc.StartInfo.WorkingDirectory = @"C:\CyberExtruder\NiFi\bin";

            //Start the process
            proc.Start();
            proc.WaitForExit();

            bool running = false;

            string output = proc.StandardOutput.ReadToEnd().ToUpper();
            if (output.Contains("CURRENTLY RUNNING"))
            {
                running = true;
            }
            return running;
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
    }
}
