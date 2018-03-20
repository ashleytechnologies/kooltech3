using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace inventory
{
    class connection
    {
        public SqlConnection con;
        public SqlCommand cmd, cmd1;
        public SqlDataReader rdr;
        public DataSet ds;
        public SqlDataAdapter adp;
        public DataTable dtable;
        public String TempFileNames2; 
        public static SqlConnection OpenConnection()
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=MELISHA;Initial Catalog=koll;Integrated Security=True");
            sqlConn.Open();
            return sqlConn;
    }

        public static SqlConnection CloseConnection()
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=MELISHA;Initial Catalog=koll;Integrated Security=True");
            sqlConn.Close();
            return sqlConn;
        }
    }
}
