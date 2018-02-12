using MySql.Data.MySqlClient;
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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = TxtitmId.Text;
            dataGridView1.Rows[n].Cells[2].Value = TxtPcs.Text;
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

        }
        public static void BulkToMySQL()
        {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
        new System.Data.SqlClient.SqlConnection("Data Source=MELISHA;Initial Catalog=kolltech;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO [dbo].[TblItem] ([ItmOrdinary] ,[ItmName] ,[ItemShortDes] ,[ItmDes] ,[ItmImage] ,[ItmVat] ,[ItmWholesalePrice] ,[ItmRetailPrice] ,[ItmMaxDiscount] ,[ItemUniqueId] ,[ItmCategory] ,[ItmSubCategory] ,[ItmBarcode] ,[Itm ReorderQuentity] ,[ItemActive] ,[ItmBrand] ,[ItmCost] ,[ItmMargine]) VALUES ('text','text','text','text','text',1,1,1,1,'text','text','text','text',1,1,'text',9,2)";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();


        }

        private void stockTakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
        }
    }
}
