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
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToString();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
        }

        private void btnCloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void barcodePrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcode fb = new frmBarcode();
            fb.ShowDialog();
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStock fs = new frmStock();
            fs.ShowDialog();
        }

    }
}
