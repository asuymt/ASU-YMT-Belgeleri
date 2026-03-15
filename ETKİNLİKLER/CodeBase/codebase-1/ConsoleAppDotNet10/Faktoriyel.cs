// ============================================================
//  FAKTORİYEL
//  n! = n × (n-1) × (n-2) × ... × 2 × 1
//  Örnek: 5! = 5 × 4 × 3 × 2 × 1 = 120
//  Özel durum: 0! = 1
// ============================================================

using System;

static class Faktoriyel
{

    // ----------------------------------------------------------
    // DEMO
    // ----------------------------------------------------------
    public static void Demo()
    {
        Console.WriteLine("=== FAKTORİYEL ===");

        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine($"  {i,2}! = {Uzun(i),10}  |  [ORTA] {Orta(i),10}  |  [KISA] {Kisa(i),10}");
        }

        Console.WriteLine();
    }


    // ----------------------------------------------------------
    // UZUN VERSİYON — For döngüsü, adım adım açıklamalı
    // ----------------------------------------------------------
    public static long Uzun(int n)
    {
        // Negatif sayının faktöriyeli tanımsız
        if (n < 0)
        {
            Console.WriteLine("Hata: Negatif sayının faktöriyeli hesaplanamaz.");
            return -1;
        }

        // 0! = 1 olarak tanımlanmıştır
        if (n == 0)
        {
            return 1;
        }

        long sonuc = 1;

        // 1'den n'e kadar tüm sayıları çarp
        for (int i = 1; i <= n; i++)
        {
            sonuc = sonuc * i;
            // Her adımı görmek ister misin?
            // Console.WriteLine($"  Adım {i}: sonuc = {sonuc}");
        }

        return sonuc;
    }

    // ----------------------------------------------------------
    // ORTA VERSİYON — Recursive (özyinelemeli)
    //  n! = n × (n-1)!
    // ----------------------------------------------------------
    public static long Orta(int n)
    {
        if (n < 0) throw new ArgumentException("Negatif sayı girilemez.");
        if (n == 0) return 1;               // base case
        return n * Orta(n - 1);             // özyinelemeli çağrı
    }

    // ----------------------------------------------------------
    // KISA VERSİYON — Expression body recursive, tek satır
    // ----------------------------------------------------------
    public static long Kisa(int n) => n <= 1 ? 1 : n * Kisa(n - 1);


}
