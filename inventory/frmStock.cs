using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inventory
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataInsert();
            dataFill();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
            dataFill();
        }

        public void dataFill()
        {
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[TblStock]", con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            adap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord;
        }

        public void dataInsert()
        {
            int itmId = int.Parse(txtItmID.Text);
            float itmAvailableQty = float.Parse(txtAvailableQty.Text);
            float itmDamagedQty = float.Parse(txtDamagedQty.Text);
            float itmToReturn = float.Parse(txtQuantitytoReturn.Text);

            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TblStock]([ItmId],[ItmAvailabePcs],[ItmDamagedPcs],[IItemToreturn]) VALUES(@itmId,@itmAvailableQty,@itmDamagedQty,@itmToReturn)", con);
            cmd.Parameters.AddWithValue("@itmId", itmId);
            cmd.Parameters.AddWithValue("@itmAvailableQty", itmAvailableQty);
            cmd.Parameters.AddWithValue("@itmDamagedQty", itmDamagedQty);
            cmd.Parameters.AddWithValue("@itmToReturn", itmToReturn);
            cmd.ExecuteNonQuery();
        }

        private void btnCloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

