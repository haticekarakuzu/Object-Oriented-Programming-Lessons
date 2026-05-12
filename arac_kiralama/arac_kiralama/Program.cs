using System;

namespace AracKiralamaSistemi
{
    class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public bool KiradaMi { get; private set; } 

        private double _gunlukUcret;
        public double GunlukUcret
        {
            get { return _gunlukUcret; }
            set
            {
                if (value >= 500)
                    _gunlukUcret = value;
                else
                    Console.WriteLine("Hata: Günlük ücret 500 TL’den az olamaz!");
            }
        }

        public Arac(string marka, string model, double gunlukUcret)
        {
            Marka = marka;
            Model = model;
            GunlukUcret = gunlukUcret;
            KiradaMi = false;
        }

        public void Kirala(int gun)
        {
            if (!KiradaMi)
            {
                KiradaMi = true;
                double toplamUcret = gun * GunlukUcret;
                Console.WriteLine($"\nİşlem Başarılı: {Marka} {Model} kiralandı.");
                Console.WriteLine($"Toplam Kira Ücreti ({gun} gün): {toplamUcret} TL");
            }
            else
            {
                Console.WriteLine("\n[!] Bu araç şu anda kirada, başka müşteriye verilemez!");
            }
        }

        public void TeslimEt()
        {
            if (KiradaMi)
            {
                KiradaMi = false;
                Console.WriteLine($"\nİşlem Başarılı: {Marka} {Model} teslim alındı. Araç artık müsait.");
            }
            else
            {
                Console.WriteLine("\n[!] Bu araç zaten teslim edilmiş (zaten galeride)!");
            }
        }

        public void BilgiYazdir()
        {
            string durum = KiradaMi ? "Kirada" : "Müsait";
            Console.WriteLine($"- {Marka} {Model} | Günlük: {GunlukUcret} TL | Durum: {durum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Arac arac1 = new Arac("Toyota", "Corolla", 1200);

            bool devamEt = true;
            while (devamEt)
            {
                Console.WriteLine("\n--- ARAÇ KİRALAMA MENÜSÜ ---");
                Console.WriteLine("1- Aracı Kirala");
                Console.WriteLine("2- Aracı Teslim Et");
                Console.WriteLine("3- Araç Bilgilerini Gör");
                Console.WriteLine("0- Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Kaç gün kiralayacaksınız? ");
                        if (int.TryParse(Console.ReadLine(), out int gun))
                        {
                            arac1.Kirala(gun);
                        }
                        break;
                    case "2":
                        arac1.TeslimEt();
                        break;
                    case "3":
                        arac1.BilgiYazdir();
                        break;
                    case "0":
                        devamEt = false;
                        Console.WriteLine("Sistemden çıkılıyor...");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }
            }
        }
    }
}