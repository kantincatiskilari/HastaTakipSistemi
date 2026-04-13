using System;
using System.Data;
using System.Data.SqlClient;

namespace HastaTakipSistemi.DAL
{

    public class HastaDAL
    {
        public DataTable TumHastalariGetir()
        {
            string sql = @"SELECT HastaID,
                                  TC,
                                  Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi,
                                  Cinsiyet,
                                  Telefon,
                                  KanGrubu,
                                  Durum,
                                  GuncelTarih
                           FROM Hastalar
                           ORDER BY Ad, Soyad";
            return DatabaseHelper.SorguCalistir(sql);
        }

        public DataTable HastaAra(string aramaMetni)
        {
            string sql = @"SELECT HastaID,
                                  TC,
                                  Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi,
                                  Cinsiyet,
                                  Telefon,
                                  KanGrubu,
                                  Durum,
                                  GuncelTarih
                           FROM Hastalar
                           WHERE Ad    LIKE @Arama
                              OR Soyad LIKE @Arama
                              OR TC    LIKE @Arama
                           ORDER BY Ad, Soyad";

            SqlParameter[] p = { new SqlParameter("@Arama", "%" + aramaMetni + "%") };
            return DatabaseHelper.SorguCalistir(sql, p);
        }

        public DataTable DurumaGoreFiltrele(string durum)
        {
            if (durum == "Tümü")
                return TumHastalariGetir();

            string sql = @"SELECT HastaID,
                                  TC,
                                  Ad + ' ' + Soyad AS AdSoyad,
                                  DogumTarihi,
                                  Cinsiyet,
                                  Telefon,
                                  KanGrubu,
                                  Durum,
                                  GuncelTarih
                           FROM Hastalar
                           WHERE Durum = @Durum
                           ORDER BY Ad, Soyad";

            SqlParameter[] p = { new SqlParameter("@Durum", durum) };
            return DatabaseHelper.SorguCalistir(sql, p);
        }
        public DataRow HastaGetirByID(int hastaID)
        {
            string sql = "SELECT * FROM Hastalar WHERE HastaID = @HastaID";
            SqlParameter[] p = { new SqlParameter("@HastaID", hastaID) };
            DataTable dt = DatabaseHelper.SorguCalistir(sql, p);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable TeshisleriGetir(int hastaID)
        {
            string sql = @"SELECT t.TeshisTarihi,
                                  p.AdSoyad AS Doktor,
                                  t.TeshisNotu,
                                  t.IlacBilgisi
                           FROM Teshisler t
                           INNER JOIN Personeller p ON t.PersonelID = p.PersonelID
                           WHERE t.HastaID = @HastaID
                           ORDER BY t.TeshisTarihi DESC";

            SqlParameter[] par = { new SqlParameter("@HastaID", hastaID) };
            return DatabaseHelper.SorguCalistir(sql, par);
        }

        public bool HastaEkle(string tc, string ad, string soyad, DateTime dogumTarihi,
                              string cinsiyet, string telefon, string adres,
                              string kanGrubu, string durum)
        {
     
            if (TCVarMi(tc))
                return false;

            string sql = @"INSERT INTO Hastalar (TC, Ad, Soyad, DogumTarihi, Cinsiyet, Telefon, Adres, KanGrubu, Durum)
                           VALUES (@TC, @Ad, @Soyad, @Dogum, @Cinsiyet, @Telefon, @Adres, @KanGrubu, @Durum)";

            SqlParameter[] p =
            {
                new SqlParameter("@TC",       tc),
                new SqlParameter("@Ad",       ad),
                new SqlParameter("@Soyad",    soyad),
                new SqlParameter("@Dogum",    dogumTarihi),
                new SqlParameter("@Cinsiyet", cinsiyet),
                new SqlParameter("@Telefon",  (object)telefon  ?? DBNull.Value),
                new SqlParameter("@Adres",    (object)adres     ?? DBNull.Value),
                new SqlParameter("@KanGrubu", (object)kanGrubu ?? DBNull.Value),
                new SqlParameter("@Durum",    durum)
            };

            return DatabaseHelper.KomutCalistir(sql, p) > 0;
        }

        public bool HastaGuncelle(int hastaID, string ad, string soyad, DateTime dogumTarihi,
                                  string cinsiyet, string telefon, string adres,
                                  string kanGrubu, string durum)
        {
            string sql = @"UPDATE Hastalar
                           SET Ad           = @Ad,
                               Soyad        = @Soyad,
                               DogumTarihi  = @Dogum,
                               Cinsiyet     = @Cinsiyet,
                               Telefon      = @Telefon,
                               Adres        = @Adres,
                               KanGrubu     = @KanGrubu,
                               Durum        = @Durum,
                               GuncelTarih  = GETDATE()
                           WHERE HastaID = @HastaID";

            SqlParameter[] p =
            {
                new SqlParameter("@HastaID",  hastaID),
                new SqlParameter("@Ad",       ad),
                new SqlParameter("@Soyad",    soyad),
                new SqlParameter("@Dogum",    dogumTarihi),
                new SqlParameter("@Cinsiyet", cinsiyet),
                new SqlParameter("@Telefon",  (object)telefon  ?? DBNull.Value),
                new SqlParameter("@Adres",    (object)adres     ?? DBNull.Value),
                new SqlParameter("@KanGrubu", (object)kanGrubu ?? DBNull.Value),
                new SqlParameter("@Durum",    durum)
            };

            return DatabaseHelper.KomutCalistir(sql, p) > 0;
        }

        public bool DurumGuncelle(int hastaID, string yeniDurum)
        {
            string sql = "UPDATE Hastalar SET Durum = @Durum, GuncelTarih = GETDATE() WHERE HastaID = @HastaID";
            SqlParameter[] p =
            {
                new SqlParameter("@HastaID", hastaID),
                new SqlParameter("@Durum",   yeniDurum)
            };
            return DatabaseHelper.KomutCalistir(sql, p) > 0;
        }

        public bool HastaSil(int hastaID)
        {
            // Önce bağlı teşhisleri sil (FK kısıtı)
            string sqlTeshis = "DELETE FROM Teshisler WHERE HastaID = @HastaID";
            string sqlHasta  = "DELETE FROM Hastalar  WHERE HastaID = @HastaID";
            SqlParameter[] p = { new SqlParameter("@HastaID", hastaID) };

            DatabaseHelper.KomutCalistir(sqlTeshis, p);
            return DatabaseHelper.KomutCalistir(sqlHasta, p) > 0;
        }

        public bool TeshisEkle(int hastaID, int personelID, string not, string ilac)
        {
            string sql = @"INSERT INTO Teshisler (HastaID, PersonelID, TeshisNotu, IlacBilgisi)
                           VALUES (@HastaID, @PersonelID, @Not, @Ilac)";
            SqlParameter[] p =
            {
                new SqlParameter("@HastaID",   hastaID),
                new SqlParameter("@PersonelID", personelID),
                new SqlParameter("@Not",        not),
                new SqlParameter("@Ilac",       (object)ilac ?? DBNull.Value)
            };
            return DatabaseHelper.KomutCalistir(sql, p) > 0;
        }

        public bool TCVarMi(string tc)
        {
            string sql = "SELECT COUNT(*) FROM Hastalar WHERE TC = @TC";
            SqlParameter[] p = { new SqlParameter("@TC", tc) };
            object sonuc = DatabaseHelper.TekDegerCek(sql, p);
            return Convert.ToInt32(sonuc) > 0;
        }

        public DataTable DurumIstatistik()
        {
            string sql = @"SELECT Durum, COUNT(*) AS Sayi
                           FROM Hastalar
                           GROUP BY Durum
                           ORDER BY Sayi DESC";
            return DatabaseHelper.SorguCalistir(sql);
        }
    }
}
