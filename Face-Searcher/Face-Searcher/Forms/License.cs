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
    public partial class License : Form
    {
        /// <summary>
        /// Load the page
        /// </summary>
        public License()
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
        /// run the MachineID.exe and get the output. From there, display it in the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void machineButton_Click(object sender, EventArgs e)
        {
            //Get the machine's key
            string op = "";
            op = Program.runEXEWithOP(@"C:\CyberExtruder\Aureus\MachineID.exe").Trim();

            //Make sure that the key was returned. If not, return something so we know it works
            if (op == "")
            {
                op = "No key returned";
            }
            //Update the MachineKeyBox and refresh it
            this.MachineKeyBox.Text = op;
            //Make sure that the color fo the text is now black
            this.MachineKeyBox.ForeColor = Color.Black;
            this.MachineKeyBox.Refresh();
        }

        /// <summary>
        /// Read from the license.txt file and display the output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LicenseButton_Click(object sender, EventArgs e)
        {
            //Read the info from the license.txt file
            string op = "";
            op = Program.readFromFile(@"C:\CyberExtruder\Aureus\License.txt");

            //Make sure that the content was returned. If not, return something so we know it works
            if (op == "")
            {
                op = "No license info found";
            }
            //Update the LicenseExpBox and refresh it
            this.LicenseExpBox.Text = op;
            //Make sure that the color fo the text is now black
            this.LicenseExpBox.ForeColor = Color.Black;
            this.LicenseExpBox.Refresh();
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
