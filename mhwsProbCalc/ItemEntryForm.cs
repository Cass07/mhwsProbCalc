using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mhwsProbCalc
{
    public partial class ItemEntryForm : Form
    {
        public string ItemName { get; private set; }
        public int ItemCount { get; private set; }
        public int WeightFactor { get; private set; }

        private TextBox txtName;
        private NumericUpDown numCount;
        private NumericUpDown numWeight;

        public ItemEntryForm(ItemEntry item = null)
        {
            this.InitializeComponent();

            if (item != null)
            {
                txtName.Text = item.getName();
                numCount.Value = item.getCount();
                numWeight.Value = item.getWeightFactor();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("이름을 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            ItemName = txtName.Text;
            ItemCount = (int)numCount.Value;
            WeightFactor = (int)numWeight.Value;
        }
    }
}
