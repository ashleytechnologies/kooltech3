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
    public partial class frmDebtors : Form
    {
        public frmDebtors()
        {
            InitializeComponent();
        }

        private void frmDebtors_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
        }
    }
}
