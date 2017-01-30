using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Face_Searcher.Forms
{
    public partial class About : Form
    {
        /// <summary>
        /// Load the page
        /// </summary>
        public About()
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
            this.Dispose();
            Program.MP.Show();
        }

        /// <summary>
        /// Open the default browser and go the following URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.allevate.com");
        }

        /// <summary>
        /// Open the setup dcumentation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Program.setupDoc);
            }
            catch
            {
                MessageBox.Show(@"Could not find file '" + Program.setupDoc + "'", "Warning", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Open the PDF in the default PDF viewer for the computer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ELUAButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Program.eluaDoc);
            }
            catch
            {
                MessageBox.Show(@"Could not find file '" + Program.eluaDoc + "'", "Warning", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Open the PDF in the default PDF viewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoPlayerSetupButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Program.videoPlayerDocumentation);
            }
            catch
            {
                MessageBox.Show(@"Could not find file '" + Program.videoPlayerDocumentation + "'", "Warning", MessageBoxButtons.OK);
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
