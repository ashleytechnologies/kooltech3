using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace inventory
{
    public partial class frmBilling : Form
    {
        public frmBilling()
        {
            InitializeComponent();
        }
                                                           
        public void clear()
        {
                          
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
                txtInvoiceNo.Text = value.ToString();
            }

        }

        public void generateCustomerID()
        {
            long value;
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [CusId] FROM [dbo].[TblCustomer] ORDER BY [CusId] DESC", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                rdr.Read();
                value = rdr.GetInt64(0);
                value++;
                txtCustomerID.Text = value.ToString();
            }

        }

        public void getProductDetails()
        {
            long value;
            SqlConnection con = connection.OpenConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [CusId] FROM [dbo].[TblCustomer] ORDER BY [CusId] DESC", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows)
            {
                rdr.Read();
                value = rdr.GetInt64(0);
                value++;
                txtCustomerID.Text = value.ToString();
            }

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBilling_Load(object sender, System.EventArgs e)
        {
            generateInvoiceID();
            generateCustomerID();
        }
    }
}
