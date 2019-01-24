using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace MiniSQL
{
    class MSSQLControls
    {
        public static string connString=@"server=DESKTOP-4BNH9IM\SQLEXPRESS;user id=sa;password=Goldquest;database=SALES-INVENTORY";
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static int rowCount=0;


        public static SqlConnection OpenConnection()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                return conn;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
                return null;
            }


        }






        public static DataTable getSource(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand(query,OpenConnection()); 
                da = new SqlDataAdapter(cmd);
                rowCount=da.Fill(dt);
                return dt;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        

    }
}
