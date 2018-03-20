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
    public partial class frmId : Form
    {
        public string id { set; get; }

        public frmId()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           // id =  textBox1.Text;
            this.Close();
        }

    }
}
