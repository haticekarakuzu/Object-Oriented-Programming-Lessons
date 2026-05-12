using System;

class baskiislem
{
    int sayfa;
    bool renkliMi;
    bool ciltliMi;
    double toplamTutar = 0;
    static int toplamBaski = 0;

    public baskiislem(int sayfa, bool renkliMi, bool ciltliMi)
    {
        this.Sayfa = sayfa;
        this.RenkliMi = renkliMi;
        this.CiltliMi = ciltliMi;
        toplamBaski++;
    }

    public int Sayfa
    {
        get { return sayfa; }
        set
        {
            if (value < 0)
                Console.WriteLine("Hata: Sayfa sayısı 0'dan küçük olamaz.");
            else
                sayfa = value;
        }
    }

    public bool RenkliMi
    {
        get { return renkliMi; }
        set { renkliMi = value; }
    }

    public bool CiltliMi
    {
        get { return ciltliMi; }
        set { ciltliMi = value; }
    }

    public double ToplamTutar
    {
        get
        {
            int sayfaUcreti = renkliMi ? 2 : 1;

            int ciltUcreti = ciltliMi ? 15 : 0;

            toplamTutar = (sayfa * sayfaUcreti) + ciltUcreti;
            return toplamTutar;
        }
    }

    public void BilgiGoster()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("Sayfa Sayısı : " + sayfa);
        Console.WriteLine("Renkli mi    : " + (renkliMi ? "Evet" : "Hayır"));
        Console.WriteLine("Ciltli mi    : " + (ciltliMi ? "Evet" : "Hayır"));
        Console.WriteLine("Toplam Tutar : " + ToplamTutar + " TL");
    }

    public static void ToplamBaskiGoster()
    {
        Console.WriteLine("\nToplam Baskı İşlemi Sayısı: " + toplamBaski);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        baskiislem b1 = new baskiislem(50, true, false);
        baskiislem b2 = new baskiislem(150, true, true);

        b1.BilgiGoster();
        b2.BilgiGoster();

        baskiislem.ToplamBaskiGoster();

        Console.ReadLine();
    }
}