using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Remote
{
    public class MyDatabase:MarshalByRefObject
    {
        public static SqlConnection conn;
        public void MoKetNoi()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=HONHATLONG-PC\SQLEXPRESS;Initial Catalog=db_Electronic;Integrated Security=True";
            conn.Open();
        }

        public DataTable AllPosition()
        {
            DataTable dt = new DataTable();
            string sql = "select TypeUser,TypeName from tbl_Position";
            SqlDataAdapter sa = new SqlDataAdapter(sql, conn);
            sa.Fill(dt);
            return dt;
        }

        public DataTable SelectStaffWhere(string chucvu)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbl_staff where TypeUser ='"+chucvu+"'";
            SqlDataAdapter sa = new SqlDataAdapter(sql, conn);
            sa.Fill(dt);
            return dt;
        }
    }
}
