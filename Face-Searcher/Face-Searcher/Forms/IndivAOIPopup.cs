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
    public partial class IndivAOIPopup : Form
    {
        public clsDefaultAOI aoi = new clsDefaultAOI();

        public IndivAOIPopup()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Load all of the values
        /// </summary>
        public void loadText()
        {
            this.TBTop.Text = aoi.top;
            this.TBLeft.Text = aoi.left;
            this.TBHeight.Text = aoi.height;
            this.TBWidth.Text = aoi.width;
            this.TBMinHead.Text = aoi.minHead;
            this.TBMaxHead.Text = aoi.maxHead;

            this.TBTop.Refresh();
            this.TBLeft.Refresh();
            this.TBHeight.Refresh();
            this.TBWidth.Refresh();
            this.TBMinHead.Refresh();
            this.TBMaxHead.Refresh();
        }

        /// <summary>
        /// Save changes then close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to save the settings", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                aoi.top = this.TBTop.Text;
                aoi.left = this.TBLeft.Text;
                aoi.height = this.TBHeight.Text;
                aoi.width = this.TBWidth.Text;
                aoi.minHead = this.TBMinHead.Text;
                aoi.maxHead = this.TBMaxHead.Text;

                this.Dispose();
            }
        }

        /// <summary>
        /// When you cancel, we want to close the popup and not save any changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Any unsaved changes will be lost. Are you sure you want to CANCEL?", "Cancel", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
