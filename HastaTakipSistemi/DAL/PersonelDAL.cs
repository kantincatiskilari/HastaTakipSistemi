using System;
using System.Data;
using System.Data.SqlClient;

namespace HastaTakipSistemi.DAL
{

    public class PersonelDAL
    {
       
        public DataRow GirisDogrula(string kullaniciAdi, string sifre)
        {
            string sql = @"SELECT PersonelID, KullaniciAdi, AdSoyad, GorevUnvani
                           FROM Personeller
                           WHERE KullaniciAdi = @KullaniciAdi
                             AND Sifre        = @Sifre";

            SqlParameter[] parametreler =
            {
                new SqlParameter("@KullaniciAdi", kullaniciAdi.Trim()),
                new SqlParameter("@Sifre",        sifre)
            };

            DataTable dt = DatabaseHelper.SorguCalistir(sql, parametreler);

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null; 
        }

   
        public DataTable TumPersonelleriGetir()
        {
            string sql = "SELECT PersonelID, AdSoyad, GorevUnvani, KullaniciAdi, KayitTarihi FROM Personeller ORDER BY AdSoyad";
            return DatabaseHelper.SorguCalistir(sql);
        }
    }
}
