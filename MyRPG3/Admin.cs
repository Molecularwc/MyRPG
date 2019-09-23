using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRPG
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible.Equals(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Barbarian_Loot_Admin barb = new Barbarian_Loot_Admin();
            barb.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Mage_Loot_Admin mage1 = new Mage_Loot_Admin();
            mage1.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Slime_Loot_Admin slime1 = new Slime_Loot_Admin();
            slime1.Show();
        }
    }
}