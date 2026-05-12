using System;

namespace SiparisSistemi
{
    class Siparis
    {
        private string _yemekAdi;
        private double _birimFiyat;
        private int _siparisAdedi;

        private static int _toplamSiparisSayisi = 0;

        
        public string YemekAdi
        {
            get { return _yemekAdi; }
            set { _yemekAdi = value; }
        }

        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set
            {
                
                if (value >= 10)
                    _birimFiyat = value;
                else
                    Console.WriteLine("Hata: Birim fiyat 10 TL'den düşük olamaz!");
            }
        }

        public int SiparisAdedi
        {
            get { return _siparisAdedi; }
            set
            {
                if (value >= 0)
                    _siparisAdedi = value;
                else
                    Console.WriteLine("Hata: Sipariş adedi negatif olamaz!");
            }
        }

        public double ToplamTutar
        {
            get { return _siparisAdedi * _birimFiyat; }
        }

        public Siparis(string yemekAdi, double birimFiyat, int adet)
        {
            this.YemekAdi = yemekAdi;
            this.BirimFiyat = birimFiyat;
            this.SiparisAdedi = adet;

            _toplamSiparisSayisi++; 
        }

       
        public void BilgiGoster()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Yemek Adı     : {YemekAdi}");
            Console.WriteLine($"Birim Fiyat   : {BirimFiyat} TL");
            Console.WriteLine($"Adet          : {SiparisAdedi}");
            Console.WriteLine($"Toplam Tutar  : {ToplamTutar} TL");
            Console.WriteLine("------------------------------");
        }

        public void AdetGuncelle(int yeniAdet)
        {
            this.SiparisAdedi = yeniAdet;
            Console.WriteLine($"{YemekAdi} siparişi {yeniAdet} adet olarak güncellendi.");
        }

        public static void ToplamSiparisSayisiGoster()
        {
            Console.WriteLine($"\nSistemdeki Toplam Sipariş Sayısı: {_toplamSiparisSayisi}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Siparis s1 = new Siparis("Adana Kebap", 250, 2);
            Siparis s2 = new Siparis("Mercimek Çorbası", 80, 1);
            Siparis s3 = new Siparis("İçli Köfte", 45, 4);

            
            Console.WriteLine("GÜNCEL SİPARİŞ LİSTESİ");
            s1.BilgiGoster();
            s2.BilgiGoster();
            s3.BilgiGoster();

            Console.WriteLine("\n--- İşlem: Adet Güncelleme ---");
            s2.AdetGuncelle(3);
            s2.BilgiGoster();

           
            Siparis.ToplamSiparisSayisiGoster();

            Console.ReadLine();
        }
    }
}