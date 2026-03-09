// ============================================================
//  ASAL SAYI KONTROLÜ
//  Bir sayı yalnızca 1 ve kendisine kalansız bölünüyorsa asaldır.
//  Örnek asal: 2, 3, 5, 7, 11, 13, 17, 19, 23 ...
// ============================================================

static class AsalSayi
{
    // ----------------------------------------------------------
    // UZUN VERSİYON — 2'den (n-1)'e kadar tek tek böl, açıklamalı
    // ----------------------------------------------------------
    public static bool Uzun(int sayi)
    {
        // 0 ve 1 asal değil
        if (sayi < 2)
        {
            return false;
        }

        // 2'den (sayi - 1)'e kadar bütün sayıları dene
        for (int bolen = 2; bolen < sayi; bolen++)
        {
            // Eğer tam bölünüyorsa asal değildir
            if (sayi % bolen == 0)
            {
                return false;
            }
        }

        // Hiçbir bölen bulunamadıysa asaldır
        return true;
    }

    // ----------------------------------------------------------
    // ORTA VERSİYON — √n'e kadar kontrol (çok daha hızlı)
    //  Matematik: eğer n = a × b ise, a veya b ≤ √n olmak zorunda.
    // ----------------------------------------------------------
    public static bool Orta(int sayi)
    {
        if (sayi < 2) return false;
        if (sayi == 2) return true;
        if (sayi % 2 == 0) return false;   // çift sayıları hızlıca ele

        int sinir = (int)Math.Sqrt(sayi);
        for (int bolen = 3; bolen <= sinir; bolen += 2)  // tek sayıları kontrol et
        {
            if (sayi % bolen == 0) return false;
        }
        return true;
    }

    // ----------------------------------------------------------
    // KISA VERSİYON — LINQ ile tek satır
    // ----------------------------------------------------------
    public static bool Kisa(int n) =>
        n >= 2 && !Enumerable.Range(2, (int)Math.Sqrt(n) - 1).Any(i => n % i == 0);

    // ----------------------------------------------------------
    // DEMO
    // ----------------------------------------------------------
    public static void Demo()
    {
        Console.WriteLine("=== ASAL SAYI ===");

        int[] testler = { 1, 2, 7, 10, 13, 49, 97 };

        foreach (int sayi in testler)
        {
            Console.WriteLine($"  {sayi,3} → [UZUN] {Uzun(sayi),5}  |  [ORTA] {Orta(sayi),5}  |  [KISA] {Kisa(sayi),5}");
        }

        Console.WriteLine("\n  1–50 arası asal sayılar:");
        Console.Write("  ");
        for (int i = 2; i <= 50; i++)
            if (Orta(i)) Console.Write(i + " ");
        Console.WriteLine("\n");
    }
}
