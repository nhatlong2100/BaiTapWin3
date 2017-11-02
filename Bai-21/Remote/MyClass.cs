using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Remote
{
    public class MyClass : MarshalByRefObject
    {
        //public MyClass() { }
        public static SqlConnection conn;

        public void MoKetNoi()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=HONHATLONG-PC\SQLEXPRESS;Initial Catalog=db_Electronic;Integrated Security=True";
            conn.Open();

        }

        public DataTable Select(string sql)
        {
            

            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(sql, conn);
            sa.Fill(dt);
            return dt;
        }

    }
}
