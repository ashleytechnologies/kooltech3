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
    public partial class frmPayments : Form
    {
        public frmPayments(Bill bill)
        {
          
            InitializeComponent();
            txtInvoiceNo.Text = bill.id.ToString();
            txtPayment.Text = bill.netAmount.ToString();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
          
        }
    }
}
