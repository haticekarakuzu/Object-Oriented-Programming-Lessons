using System;

namespace SinemaSistemi
{
    class Salon
    {
        public string SalonAdi { get; set; }
        private int _kapasite;
        private double _biletFiyati;

        public int Kapasite
        {
            get { return _kapasite; }
            set
            {
                if (value > 0) _kapasite = value;
                else Console.WriteLine("Hata: Kapasite 0'dan büyük olmalıdır.");
            }
        }

        public double BiletFiyati
        {
            get { return _biletFiyati; }
            set
            {
                if (value >= 50) _biletFiyati = value;
                else Console.WriteLine("Hata: Bilet fiyatı en az 50 TL olmalıdır.");
            }
        }

        public int DoluKoltukSayisi { get; private set; }

        public Salon(string salonAdi, int kapasite, double biletFiyati)
        {
            SalonAdi = salonAdi;
            Kapasite = kapasite;
            BiletFiyati = biletFiyati;
            DoluKoltukSayisi = 0;
        }

        public void BiletSat(int adet)
        {
            if (adet <= 0)
            {
                Console.WriteLine("Hata: Satış adedi 0'dan büyük olmalıdır.");
                return;
            }

            if (DoluKoltukSayisi + adet > Kapasite)
            {
                Console.WriteLine($"Hata: Yeterli boş koltuk yok! (Mevcut Boş: {Kapasite - DoluKoltukSayisi})");
            }
            else
            {
                DoluKoltukSayisi += adet;
                double tutar = adet * BiletFiyati;
                Console.WriteLine($"{adet} adet bilet satıldı. Toplam Tutar: {tutar} TL");
            }
        }

        public void BiletIade(int adet)
        {
            if (adet <= 0)
            {
                Console.WriteLine("Hata: İade adedi 0'dan büyük olmalıdır.");
            }
            else if (DoluKoltukSayisi - adet < 0)
            {
                Console.WriteLine("Hata: İade edilecek bilet sayısı dolu koltuk sayısından fazla olamaz!");
            }
            else
            {
                DoluKoltukSayisi -= adet;
                Console.WriteLine($"{adet} adet bilet iade edildi.");
            }
        }

        public double DolulukOraniHesapla()
        {
            return ((double)DoluKoltukSayisi / Kapasite) * 100;
        }

        public void BilgiGoster()
        {
            Console.WriteLine("\n--- SALON BİLGİLERİ ---");
            Console.WriteLine($"Salon Adı          : {SalonAdi}");
            Console.WriteLine($"Kapasite           : {Kapasite}");
            Console.WriteLine($"Dolu Koltuk Sayısı : {DoluKoltukSayisi}");
            Console.WriteLine($"Boş Koltuk Sayısı  : {Kapasite - DoluKoltukSayisi}");
            Console.WriteLine($"Doluluk Oranı      : %{DolulukOraniHesapla():F2}");
            Console.WriteLine("-----------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Salon salon1 = new Salon("Salon A - IMAX", 50, 120);

            bool devamEt = true;
            while (devamEt)
            {
                Console.WriteLine("1) Bilet Sat");
                Console.WriteLine("2) Bilet İade");
                Console.WriteLine("3) Bilgileri Göster");
                Console.WriteLine("0) Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Kaç bilet satılacak? ");
                        int satAdet = int.Parse(Console.ReadLine());
                        salon1.BiletSat(satAdet);
                        break;
                    case "2":
                        Console.Write("Kaç bilet iade edilecek? ");
                        int iadeAdet = int.Parse(Console.ReadLine());
                        salon1.BiletIade(iadeAdet);
                        break;
                    case "3":
                        salon1.BilgiGoster();
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