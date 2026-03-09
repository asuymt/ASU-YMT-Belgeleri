// ============================================================
//  FİBONACCİ SAYILARI
//  0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...
//  Her sayı, kendisinden önceki iki sayının toplamıdır.
// ============================================================

static class Fibonacci
{


    // ----------------------------------------------------------
    // DEMO: Üç versiyonu karşılaştır
    // ----------------------------------------------------------
    public static void Demo()
    {
        Console.WriteLine("=== FİBONACCİ ===");

        int test = 10;

        Console.WriteLine($"  [UZUN]  F({test}) = {Uzun(test)}");
        Console.WriteLine($"  [ORTA]  F({test}) = {Orta(test)}");
        Console.WriteLine($"  [KISA]  F({test}) = {Kisa(test)}");

        Console.WriteLine("\n  İlk 10 Fibonacci sayısı:");
        Console.Write("  ");
        for (int i = 0; i < 10; i++)
            Console.Write(Uzun(i) + (i < 9 ? ", " : "\n"));

        Console.WriteLine();
    }

    // ----------------------------------------------------------
    // UZUN VERSİYON — Her adım açıklamalı, öğrenci dostu
    // ----------------------------------------------------------
    public static long Uzun(int n)
    {
        // Negatif sayı girilirse hata ver
        if (n < 0)
        {
            Console.WriteLine("Hata: Negatif sayı girilemez.");
            return -1;
        }

        // Temel durumlar (base case)
        // F(0) = 0 tanım gereği
        if (n == 0)
        {
            return 0;
        }

        // F(1) = 1 tanım gereği
        if (n == 1)
        {
            return 1;
        }

        // Önceki iki terimi tutan değişkenler
        long onceki = 0;   // F(n-2)
        long simdiki = 1;   // F(n-1)

        // 2'den n'e kadar her adımı tek tek hesapla
        for (int i = 2; i <= n; i++)
        {
            long sonraki = onceki + simdiki; // F(i) = F(i-2) + F(i-1)
            onceki = simdiki;               // bir sonraki adım için kaydır
            simdiki = sonraki;
        }

        return simdiki;
    }

    // ----------------------------------------------------------
    // ORTA VERSİYON — Döngü ama daha öz yazım
    // ----------------------------------------------------------
    public static long Orta(int n)
    {
        if (n < 0) throw new ArgumentException("Negatif sayı girilemez.");
        if (n <= 1) return n;

        long a = 0, b = 1;
        for (int i = 2; i <= n; i++)
            (a, b) = (b, a + b);   // tuple swap — iki satır bir satıra indi

        return b;
    }

    // ----------------------------------------------------------
    // KISA VERSİYON — Özyinelemeli (recursive), tek satır
    // ----------------------------------------------------------
    public static long Kisa(int n) =>
        n <= 1 ? n : Kisa(n - 1) + Kisa(n - 2);

}
