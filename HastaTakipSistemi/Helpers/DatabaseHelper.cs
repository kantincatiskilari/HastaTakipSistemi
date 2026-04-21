using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaTakipSistemi.Helpers
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
            catch { return false; }
        }

        public static DataTable SorguCalistir(string sql, SqlParameter[] p = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (p != null) cmd.Parameters.AddRange(p);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public static int KomutCalistir(string sql, SqlParameter[] p = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (p != null) cmd.Parameters.AddRange(p);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static object TekDegerCek(string sql, SqlParameter[] p = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (p != null) cmd.Parameters.AddRange(p);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static DataRow GirisDogrula(string kullaniciAdi, string sifre)
        {
            string sql = @"SELECT PersonelID, KullaniciAdi, AdSoyad, GorevUnvani FROM Personeller
                           WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

            SqlParameter[] p =
            {
                new SqlParameter("@KullaniciAdi", kullaniciAdi.Trim()),
                new SqlParameter("@Sifre",        sifre)
            };

            DataTable dt = SorguCalistir(sql, p);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

  
        public static DataTable TumHastalariGetir()
        {
            string sql = @"SELECT HastaID, TC, Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi, Cinsiyet, Telefon,
                                  KanGrubu, Durum, GuncelTarih
                           FROM Hastalar ORDER BY Ad, Soyad";
            return SorguCalistir(sql);
        }

        public static DataTable HastaAra(string aramaMetni)
        {
            string sql = @"SELECT HastaID, TC, Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi, Cinsiyet, Telefon,
                                  KanGrubu, Durum, GuncelTarih
                           FROM Hastalar
                           WHERE Ad LIKE @Arama OR Soyad LIKE @Arama OR TC LIKE @Arama
                           ORDER BY Ad, Soyad";

            SqlParameter[] p = { new SqlParameter("@Arama", "%" + aramaMetni + "%") };
            return SorguCalistir(sql, p);
        }

        public static DataTable DurumaGoreFiltrele(string durum)
        {
            if (durum == "Tümü") return TumHastalariGetir();

            string sql = @"SELECT HastaID, TC, Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi, Cinsiyet, Telefon,
                                  KanGrubu, Durum, GuncelTarih
                           FROM Hastalar WHERE Durum = @Durum
                           ORDER BY Ad, Soyad";

            SqlParameter[] p = { new SqlParameter("@Durum", durum) };
            return SorguCalistir(sql, p);
        }

        public static DataTable DogumTarihineGoreFiltrele(DateTime baslangic, DateTime bitis)
        {
            string sql = @"SELECT HastaID, TC, Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi, Cinsiyet, Telefon,
                                  KanGrubu, Durum, GuncelTarih
                           FROM Hastalar
                           WHERE DogumTarihi BETWEEN @Baslangic AND @Bitis
                           ORDER BY DogumTarihi";

            SqlParameter[] p =
            {
                new SqlParameter("@Baslangic", baslangic.Date),
                new SqlParameter("@Bitis",     bitis.Date)
            };
            return SorguCalistir(sql, p);
        }

        public static DataRow HastaGetirByID(int hastaID)
        {
            string sql = "SELECT * FROM Hastalar WHERE HastaID = @HastaID";
            SqlParameter[] p = { new SqlParameter("@HastaID", hastaID) };
            DataTable dt = SorguCalistir(sql, p);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool TCVarMi(string tc)
        {
            string sql = "SELECT COUNT(*) FROM Hastalar WHERE TC = @TC";
            SqlParameter[] p = { new SqlParameter("@TC", tc) };
            return Convert.ToInt32(TekDegerCek(sql, p)) > 0;
        }

        public static bool HastaEkle(string tc, string ad, string soyad, DateTime dogum,
                                     string cinsiyet, string telefon, string adres,
                                     string kanGrubu, string durum)
        {
            if (TCVarMi(tc)) return false;

            string sql = @"INSERT INTO Hastalar (TC, Ad, Soyad, DogumTarihi, Cinsiyet, Telefon, Adres, KanGrubu, Durum)
                           VALUES (@TC, @Ad, @Soyad, @Dogum, @Cinsiyet, @Telefon, @Adres, @KanGrubu, @Durum)";

            SqlParameter[] p =
            {
                new SqlParameter("@TC",       tc),
                new SqlParameter("@Ad",       ad),
                new SqlParameter("@Soyad",    soyad),
                new SqlParameter("@Dogum",    dogum),
                new SqlParameter("@Cinsiyet", cinsiyet),
                new SqlParameter("@Telefon",  (object)telefon  ?? DBNull.Value),
                new SqlParameter("@Adres",    (object)adres    ?? DBNull.Value),
                new SqlParameter("@KanGrubu", (object)kanGrubu ?? DBNull.Value),
                new SqlParameter("@Durum",    durum)
            };
            return KomutCalistir(sql, p) > 0;
        }

        public static bool HastaGuncelle(int hastaID, string ad, string soyad, DateTime dogum,
                                         string cinsiyet, string telefon, string adres,
                                         string kanGrubu, string durum)
        {
            string sql = @"UPDATE Hastalar
                           SET Ad = @Ad, Soyad = @Soyad, DogumTarihi = @Dogum,
                               Cinsiyet = @Cinsiyet, Telefon = @Telefon, Adres = @Adres,
                               KanGrubu = @KanGrubu, Durum = @Durum, GuncelTarih = GETDATE()
                           WHERE HastaID = @HastaID";

            SqlParameter[] p =
            {
                new SqlParameter("@HastaID",  hastaID),
                new SqlParameter("@Ad",       ad),
                new SqlParameter("@Soyad",    soyad),
                new SqlParameter("@Dogum",    dogum),
                new SqlParameter("@Cinsiyet", cinsiyet),
                new SqlParameter("@Telefon",  (object)telefon  ?? DBNull.Value),
                new SqlParameter("@Adres",    (object)adres    ?? DBNull.Value),
                new SqlParameter("@KanGrubu", (object)kanGrubu ?? DBNull.Value),
                new SqlParameter("@Durum",    durum)
            };
            return KomutCalistir(sql, p) > 0;
        }

        public static bool HastaSil(int hastaID)
        {
            SqlParameter[] p = { new SqlParameter("@HastaID", hastaID) };
            KomutCalistir("DELETE FROM Teshisler WHERE HastaID = @HastaID", p);
            return KomutCalistir("DELETE FROM Hastalar WHERE HastaID = @HastaID", p) > 0;
        }

        public static DataTable TeshisleriGetir(int hastaID)
        {
            string sql = @"SELECT t.TeshisTarihi, p.AdSoyad AS Doktor,
                                  t.TeshisNotu, t.IlacBilgisi
                           FROM Teshisler t
                           INNER JOIN Personeller p ON t.PersonelID = p.PersonelID
                           WHERE t.HastaID = @HastaID
                           ORDER BY t.TeshisTarihi DESC";

            SqlParameter[] p = { new SqlParameter("@HastaID", hastaID) };
            return SorguCalistir(sql, p);
        }

        public static bool TeshisEkle(int hastaID, int personelID, string not, string ilac)
        {
            string sql = @"INSERT INTO Teshisler (HastaID, PersonelID, TeshisNotu, IlacBilgisi)
                           VALUES (@HastaID, @PersonelID, @Not, @Ilac)";

            SqlParameter[] p =
            {
                new SqlParameter("@HastaID",    hastaID),
                new SqlParameter("@PersonelID", personelID),
                new SqlParameter("@Not",        not),
                new SqlParameter("@Ilac",       (object)ilac ?? DBNull.Value)
            };
            return KomutCalistir(sql, p) > 0;
        }

        public static DataTable DurumIstatistik()
        {
            string sql = @"SELECT Durum, COUNT(*) AS Sayi
                           FROM Hastalar GROUP BY Durum ORDER BY Sayi DESC";
            return SorguCalistir(sql);
        }
    }
}