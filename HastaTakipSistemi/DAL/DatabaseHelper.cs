using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipSistemi.DAL
{
 
    public static class DatabaseHelper
    {

        private static readonly string ConnectionString =
            "Server=DESKTOP-CDUPO4I;Database=HastaTakipDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }


        public static bool BaglantiTest()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

       
        public static DataTable SorguCalistir(string sql, SqlParameter[] parametreler = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parametreler != null)
                        cmd.Parameters.AddRange(parametreler);

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }


        public static int KomutCalistir(string sql, SqlParameter[] parametreler = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parametreler != null)
                        cmd.Parameters.AddRange(parametreler);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

 
        public static object TekDegerCek(string sql, SqlParameter[] parametreler = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parametreler != null)
                        cmd.Parameters.AddRange(parametreler);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
