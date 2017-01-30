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
    public partial class AOI : Form
    {
        /// <summary>
        /// Load the page
        /// </summary>
        public AOI()
        {
            InitializeComponent();

            this.FormClosing += Form_FormClosing;
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
            if (hasChanges())
            {
                if (MessageBox.Show("If you leave this screen yout will lose any unsaved changes. Would you like to leave this screen", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Dispose();
                    Program.MP.Show();
                }
            }
            else
            {
                this.Dispose();
                Program.MP.Show();
            }
        }

        /// <summary>
        /// Save the default AOI settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Prompt the user to save before actually saving
            if (MessageBox.Show("Are you sure that you would like to save the default A.O.I. settings", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //assign the values of the text boxes to the default class
                string strContent = this.topBox.Text + "," + this.leftBox.Text + "," + this.heightBox.Text + "," + this.widthBox.Text + "," + this.minheadBox.Text + "," + this.maxheadBox.Text;
                Program.defaultAOI.loadDefaults(strContent);
                Program.defaultAOI.saveSettings();
            }
        }

        /// <summary>
        /// Do on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AOI_Load(object sender, EventArgs e)
        {
            //Get a clone of the default
            clsDefaultAOI tempAOI = new clsDefaultAOI();
            tempAOI = Program.defaultAOI.clone();

            //Set all of the fields
            this.topBox.Text = tempAOI.top;
            this.leftBox.Text = tempAOI.left;
            this.heightBox.Text = tempAOI.height;
            this.widthBox.Text = tempAOI.width;
            this.minheadBox.Text = tempAOI.minHead;
            this.maxheadBox.Text = tempAOI.maxHead;
            
            this.Refresh();
        }

        /// <summary>
        /// Check if the current settings are different from the default settings
        /// </summary>
        /// <returns></returns>
        private bool hasChanges()
        {
            bool blnReturn = false;
            
            if(this.topBox.Text != Program.defaultAOI.top)
            {
                blnReturn = true; //Did not match
            }

            if (this.leftBox.Text != Program.defaultAOI.left)
            {
                blnReturn = true; //Did not match
            }

            if (this.heightBox.Text != Program.defaultAOI.height)
            {
                blnReturn = true; //Did not match
            }

            if (this.widthBox.Text != Program.defaultAOI.width)
            {
                blnReturn = true; //Did not match
            }

            if (this.minheadBox.Text != Program.defaultAOI.minHead)
            {
                blnReturn = true; //Did not match
            }

            if (this.maxheadBox.Text != Program.defaultAOI.maxHead)
            {
                blnReturn = true; //Did not match
            }

            return blnReturn;
        }

        /// <summary>
        /// Open the video stream player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Program.videoPlayer);
            }
            catch
            {
                MessageBox.Show(@"Could not find file '" + Program.videoPlayer + "'", "Warning", MessageBoxButtons.OK);
            }
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
