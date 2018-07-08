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
    public partial class frmReceipts : Form
    {
        public frmReceipts()
        {
            InitializeComponent();
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
        }

        private void btnCloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
