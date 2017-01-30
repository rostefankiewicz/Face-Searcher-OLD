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
    public partial class EmailSetup : Form
    {
        /// <summary>
        /// Load the form
        /// </summary>
        public EmailSetup()
        {
            InitializeComponent();

            this.FormClosing += Form_FormClosing;

            loadEmail();
        }

        /// <summary>
        /// Load the cameras to the text box
        /// </summary>
        public void loadEmail()
        {
            int endCount = Program.toEmails.Count - 1;
            for (int i = 0; i < Program.toEmails.Count; i++)
            {
                if (i == endCount)
                {
                    this.ToEmailTB.Text += Program.toEmails[i];
                }
                else
                {
                    this.ToEmailTB.Text += Program.toEmails[i] + ",\r\n";
                }
            }
        }

        /// <summary>
        /// Save the email settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Program.toEmails.Clear();
            string[] separated = this.ToEmailTB.Text.Replace("\r\n", "").Replace(" ", "").Split(',');
            for (int i = 0; i < separated.Length; i++)
            {
                Program.toEmails.Add(separated[i].Trim());
            }
            Program.saveEmail();
        }

        /// <summary>
        /// Go back to the main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Program.MP.Show();
        }

        /// <summary>
        /// Call the close application function
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
