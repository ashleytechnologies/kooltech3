using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace inventory
{
    public partial class frmInvoiceCancellation : Form
    {
        public frmInvoiceCancellation()
        {
            InitializeComponent();
        }


        public void generateLastInvoiceID()
        {
            long value;
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [ItmId] FROM [dbo].[TblItem] WHERE [InvActive]==0 ORDER BY [ItmId] DESC", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                rdr.Read();
                value = rdr.GetInt64(0);
                lblLastCancelledInv.Text = value.ToString();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int InvoiceNo = int.Parse(txtInvoiceNo.Text);
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("Update  [dbo].[TblItem] Set [InvActive]==0 WHERE [ItmId]==@ItmId", con);
            cmd.Parameters.AddWithValue("@ItmId", InvoiceNo);
            cmd.ExecuteNonQuery();

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Invoice Cancelled Successfuly.");
            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }

        private void frmInvoiceCancellation_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
        }
    }
}
