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
    public partial class MainPage : Form
    {
        /// <summary>
        /// Load the page
        /// </summary>
        public MainPage()
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

        //====== WHEN OPENING NEW FORMS, DO NOT CLOSE() MAINPAGE. THIS WILL KILL THE APPLICATION ======

        /// <summary>
        /// Open the setup documentation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setUpDocButton_Click(object sender, EventArgs e)
        {
            this.Hide(); //equivelent to me.hide() in VB
            Program.about = new About(); //Declare the new form
            Program.about.Show(); //Show the new form
        }

        /// <summary>
        /// Open the License Info form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void licenseInfoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.license = new License();
            Program.license.Show();
        }

        /// <summary>
        /// Open the Default AOI setting form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aoiSettingButton_Click(object sender, EventArgs e)
        {
            this.Hide(); //equivelent to me.hide() in VB
            Program.aoi = new AOI(); //Declare the new form
            Program.aoi.Show(); //Show the new form
        }

        /// <summary>
        /// Open the Config/Start Camera page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cameraButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.camera = new Camera();
            Program.camera.Show();
        }

        /// <summary>
        /// Open the Config/Start NiFi form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nifiButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.nifi = new NiFi();
            Program.nifi.Show();
        }

        /// <summary>
        /// Open the emailSetup form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emailSetup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.email = new EmailSetup();
            Program.email.Show();
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
