using System;

namespace StokYonetimSistemi
{
    class Urun
    {
        public string Ad { get; set; }
        private int _stokMiktari;

        public Urun(string ad, int stokMiktari)
        {
            Ad = ad;
            _stokMiktari = stokMiktari;
        }

        public void SatisYap(int adet)
        {
            if (adet <= _stokMiktari)
            {
                _stokMiktari -= adet;
                Console.WriteLine($"{adet} adet satış yapıldı. Kalan stok: {_stokMiktari}");
            }
            else
            {
                Console.WriteLine("Hata: Stok yetersiz!");
            }
        }

        public void StokEkle(int miktar)
        {
            if (miktar > 0)
            {
                _stokMiktari += miktar;
                Console.WriteLine($"{miktar} adet stok eklendi. Yeni stok: {_stokMiktari}");
            }
        }

        public int KalanStok()
        {
            return _stokMiktari;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Urun urun1 = new Urun("Kulaklık", 10);
            bool devamEt = true;

            Console.WriteLine($"--- {urun1.Ad} Stok Yönetim Sistemine Hoş Geldiniz ---");

            while (devamEt)
            {
               
                Console.WriteLine("\nLütfen bir işlem seçiniz:");
                Console.WriteLine("1- Satış Yap");
                Console.WriteLine("2- Stok Ekle");
                Console.WriteLine("3- Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Satış yapılacak adet: ");
                        int satisAdedi = int.Parse(Console.ReadLine());
                        urun1.SatisYap(satisAdedi);
                        break;

                    case "2":
                        Console.Write("Eklenecek stok miktarı: ");
                        int eklenenMiktar = int.Parse(Console.ReadLine());
                        urun1.StokEkle(eklenenMiktar);
                        break;

                    case "3":
                        devamEt = false;
                        Console.WriteLine("Programdan çıkılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyiniz.");
                        break;
                }

                if (urun1.KalanStok() <= 0)
                {
                    Console.WriteLine("\n--- Ürün stoğu tükendi. ---");
                    devamEt = false;
                }
            }

            Console.WriteLine("İşlem tamamlandı. Kapatmak için bir tuşa basın.");
            Console.ReadKey();
        }
    }
}