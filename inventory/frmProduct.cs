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
    public partial class frmProduct : Form
    {
        public frmProduct()
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
            string ItmOrdinary = txtProductCode.Text;
            string ItmName = txtProductName.Text;
            string ItemShortDes = txtProductDescription.Text;
            string BarCode = txtBarcode.Text;
            string BrandCode = txtBrandCode.Text;
            float ReOrderQuantity = float.Parse(txtReorderQty.Text);
            string ImageName = img_name.Text;
            string ItmActive = chkActive.Checked.ToString();
            float ItmPrice = float.Parse(txtCost.Text);
            float ItmMaxDiscount = float.Parse(txtMaxDisPrecentage.Text);
            string ItmCategory = txtCategory.Text;
            string ItmSubCategory = txtSubCategory.Text;
            float ItmReorderQuentity = float.Parse(txtReorderQty.Text);
            bool ItemActive = true;
            string ItmBrand = txtBrandCode.Text;
            float ItmMargine = float.Parse(txtMargin.Text);
            float ItmWholesalePrice = float.Parse(txtWholeSalePrice.Text);

            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TblItem]([ItmOrdinary] ,[ItmName] ,[ItemShortDes] ,[ItmImage] ,[ItmRetailPrice] ,[ItmMaxDiscount] ,[ItmCategory] ,[ItmSubCategory] ,[ItmBarcode] ,[ItmReorderQuentity] ,[ItemActive] ,[ItmBrand], [ItmMargine], [ItmWholesalePrice]) VALUES (@ItmOrdinary,@ItmName,@ItemShortDes,@ItmImage,@ItmRetailPrice,@ItmMaxDiscount,@ItmCategory,@ItmSubCategory,@ItmBarcode,@ItmReorderQuentity,@ItemActive,@ItmBrand,@ItmMargine,@ItmWholesalePrice)", con);
            cmd.Parameters.AddWithValue("@ItmOrdinary", ItmOrdinary);
            cmd.Parameters.AddWithValue("@ItmName", ItmName);
            cmd.Parameters.AddWithValue("@ItemShortDes", ItemShortDes);
            cmd.Parameters.AddWithValue("@ItmImage", ImageName);
            cmd.Parameters.AddWithValue("@ItmRetailPrice", ItmPrice);
            cmd.Parameters.AddWithValue("@ItmMaxDiscount", ItmMaxDiscount);
            cmd.Parameters.AddWithValue("@ItmCategory", ItmCategory);
            cmd.Parameters.AddWithValue("@ItmSubCategory", ItmSubCategory);
            cmd.Parameters.AddWithValue("@ItmBarcode", BarCode);
            cmd.Parameters.AddWithValue("@ItmReorderQuentity", ItmReorderQuentity);
            cmd.Parameters.AddWithValue("@ItemActive", ItemActive);
            cmd.Parameters.AddWithValue("@ItmBrand", ItmBrand);
            cmd.Parameters.AddWithValue("@ItmMargine", ItmMargine);
            cmd.Parameters.AddWithValue("@ItmWholesalePrice", ItmWholesalePrice);

            cmd.ExecuteNonQuery();

            if (cmd.ExecuteNonQuery() == 1)
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

        private void upload_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(open.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                img_name.Text = open.FileName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmId fd = new frmId();
            fd.ShowDialog();
            string id_search = fd.id.ToString();

            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[TblItem] where [ItmOrdinary]=@ItmOrdinary", con);
            cmd.Parameters.AddWithValue("@ItmOrdinary", id_search);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            adap.Fill(dtRecord);
            txtBarcode.Text = dtRecord.ToString();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmId fd = new frmId();
            fd.ShowDialog();
            string id_search = fd.id.ToString();

            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[TblItem] where [ItmOrdinary]=@ItmOrdinary", con);
            cmd.Parameters.AddWithValue("@ItmOrdinary", id_search);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            adap.Fill(dtRecord);

            SqlDataReader rdr = cmd.ExecuteReader();
            using (rdr)
                if (rdr.Read())
                {
                    txtProductCode.Text = (rdr["ItmOrdinary"].ToString());
                    txtProductName.Text = (rdr["ItmName"].ToString());

                    con.Close();
                }
        }

        private void txtDisPrecentage_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CleartextBoxes();
        }

        public void CleartextBoxes()
        {

            foreach (Control Cleartext in this.Controls)
            {

                if (Cleartext is TextBox)
                {
                    (Cleartext as TextBox).Clear();
                    
                }

                else if (Cleartext is GroupBox)
                {
                    if (Cleartext is TextBox)
                    {
                        (Cleartext as TextBox).Clear();

                    }

                }

            }

        }
    }
}
