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
    public partial class frmSalesReturn : Form
    {
        public frmSalesReturn()
        {
            InitializeComponent();
        }

        private void frmSalesReturn_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
        }

        private void btnCloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
