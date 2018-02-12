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
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
            generateLastInvoiceID();
            generateInvoiceID();
        }

        public void generateInvoiceID()
        {
            long value;
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [ItmId] FROM [dbo].[TblItem] ORDER BY [ItmId] DESC", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                rdr.Read();
                value = rdr.GetInt64(0);
                value++;
                lblInvNo.Text = value.ToString();
            }

        }

        public void generateLastInvoiceID()
        {
            long value;
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [ItmId] FROM [dbo].[TblItem] ORDER BY [ItmId] DESC", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                rdr.Read();
                value = rdr.GetInt64(0);
                lblLastInv.Text = value.ToString();
            }

        }

        private void TxtQuantity_Leave(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = txtProductID.Text;
            dataGridView1.Rows[n].Cells[2].Value = TxtQuantity.Text;
            dataGridView1.Rows[n].Cells[3].Value = TxtDiscouont.Text;
            dataGridView1.Rows[n].Cells[4].Value = TxtPrice.Text;
            dataGridView1.Rows[n].Cells[5].Value = TxtPrice.Text;
            if (n < 1)
            {
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToDecimal(TxtPrice.Text);
            }
            else if (n > 0)
            {
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToDecimal(TxtPrice.Text) + Convert.ToDecimal(dataGridView1.Rows[n - 1].Cells[6].Value);
            }
            BulkToMySQL();

            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            lblGrossAmt.Text = sum.ToString();

        }

        public static void BulkToMySQL()
        {
            SqlConnection con = connection.OpenConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [dbo].[TblItem] ([ItmOrdinary] ,[ItmName] ,[ItemShortDes] ,[ItmDes] ,[ItmImage] ,[ItmVat] ,[ItmWholesalePrice] ,[ItmRetailPrice] ,[ItmMaxDiscount] ,[ItemUniqueId] ,[ItmCategory] ,[ItmSubCategory] ,[ItmBarcode] ,[Itm ReorderQuentity] ,[ItemActive] ,[ItmBrand] ,[ItmCost] ,[ItmMargine], [ItmPrice]) VALUES ('text','text','text','text','text',1,1,1,1,'text','text','text','text',1,1,'text',9,2,200.00)";
            cmd.Connection = con;

           cmd.ExecuteNonQuery();


        }

        private void btnCloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtProductID_Leave(object sender, EventArgs e)
        {
            string productId = txtProductID.Text;
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT [ItmName],[ItmPrice],[ItmBarcode],[ItemActive],[ItmBrand] FROM [dbo].[TblItem] WHERE [ItmId]=(@productID)", con);
            cmd.Parameters.AddWithValue("@productID", productId);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                rdr.Read();

                string name = rdr.GetString(0);
                TxtPrice.Text = rdr.GetDecimal(1).ToString();
                Boolean active = rdr.GetBoolean(3);

                if(active == false)
                {
                    MessageBox.Show("Sorry item not available in stock.");
                }


            }
        }

        private void TxtDiscouont_Leave(object sender, EventArgs e)
        {
            Double price = Convert.ToDouble(TxtPrice.Text);
            Double discount = Convert.ToDouble(TxtDiscouont.Text);
            Double disval = (price*(discount/100));

            txtDisVal.Text = disval.ToString();
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            Object obj = new Object();
            Bill bill = new Bill { id = 1,grossAmount=0,discount=0 , itemDiscount=0, netAmount=0};
            bill.id = Convert.ToInt32(lblInvNo.Text);
            bill.grossAmount = float.Parse(lblGrossAmt.Text);
            bill.discount = float.Parse(lblDiscount.Text);
            bill.itemDiscount = float.Parse(lblItemDis.Text);
            bill.netAmount = float.Parse(lblNetAmt.Text);
            frmPayments fp = new frmPayments(bill);
        }

        private void stockTakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.Show();
        }
    }
}
