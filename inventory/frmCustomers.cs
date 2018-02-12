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
    public partial class frmCustomers : Form
    {
        public frmCustomers()
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

        public void dataInsertion()
        {
           int CusId = int.Parse(txtCustomerCode.Text);
           string CusName = txtCustomerCode.Text;
            string CusAddress = txtCustomerAddress1.Text;
            string CusEmail =txtCustomerEmail.Text;
            string CusMobile = txtCustomerTel.Text;
            string CusNic = txtCustomerNIC.Text;
            float CusCreditLimit = float.Parse(txtCreditLimit.Text);

            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TblCustomer]([CusName],[CusAddress],[CusEmail],[CusMobile],[CusNic],[CusCreditLimit],[Active]) VALUES(@CusName,@CusAddress,@CusEmail,@CusMobile,@CusNic,@CusCreditLimit,'1')", con);
            //cmd.Parameters.AddWithValue("@CusId", CusId);
            cmd.Parameters.AddWithValue("@CusName", CusName);
            cmd.Parameters.AddWithValue("@CusAddress", CusAddress);
            cmd.Parameters.AddWithValue("@CusEmail", CusEmail);
            cmd.Parameters.AddWithValue("@CusMobile", CusMobile);
            cmd.Parameters.AddWithValue("@CusNic", CusNic);
            cmd.Parameters.AddWithValue("@CusCreditLimit", CusCreditLimit);
            cmd.ExecuteNonQuery();

            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Inserted Successfuly.");

            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            dataInsertion();
        }


    }
}
