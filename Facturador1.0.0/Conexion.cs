using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Facturador1._0._0
{
    public class Conexion
    {
        public static SqlConnection cn()
        {
            string Cadecone = Settings1.Default.Cade_Conexion;
            SqlConnection cn = new SqlConnection(Cadecone);
            return cn;
        }

        public static DataSet Ejecutar_ds(string cmd)
        {
            string Cadecone = Settings1.Default.Cade_Conexion;
            SqlConnection con = new SqlConnection(Cadecone);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd, con);
            da.Fill(ds);
            con.Close();
            return ds;

        }
        public static DataTable Ejecutar_dt(string cmd)
        {
            
            string Cadecone = Settings1.Default.Cade_Conexion;
            SqlConnection con = new SqlConnection(Cadecone);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd, con);
            da.Fill(dt);
            con.Close();
            return dt;

        }

    }
}
