namespace HastaTakipSistemi.Models
{

    public static class Oturum
    {
        public static int    PersonelID    { get; set; }
        public static string KullaniciAdi  { get; set; }
        public static string AdSoyad       { get; set; }
        public static string GorevUnvani   { get; set; }
        public static bool   GirisDurumu   { get; set; } = false;

        public static void Temizle()
        {
            PersonelID   = 0;
            KullaniciAdi = null;
            AdSoyad      = null;
            GorevUnvani  = null;
            GirisDurumu  = false;
        }
    }
}
