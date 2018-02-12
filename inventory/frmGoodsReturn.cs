using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inventory
{
    public partial class frmGoodsReturn : Form
    {
        public frmGoodsReturn()
        {
            InitializeComponent();
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReturn sr = new frmSalesReturn();
            sr.ShowDialog();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goodsReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGoodsReturn gr = new frmGoodsReturn();
            gr.ShowDialog();
        }
    }
}
