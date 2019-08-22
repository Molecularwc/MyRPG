using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRPG3
{
    public partial class Mage_Loot_Admin : Form
    {
        public Mage_Loot_Admin()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //the following code is done when the add new item button is clicked on the navigator
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[]
            {
                "White", "Green", "Blue", "Purple", "Gold"
            });
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mage_Loot_Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loot.mage_loot_drops' table. You can move, or remove it, as needed.
            this.SuspendLayout();
            this.mage_loot_dropsTableAdapter.Fill(this.loot.mage_loot_drops);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.magelootdropsBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.loot);
            MessageBox.Show("Mage Items saved successfully");
        }
    }
}