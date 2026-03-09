// ============================================================
//  IF - ELSE BLOKLARI
//  Koşula göre farklı kod bloklarını çalıştırır.
//  if (koşul) { ... } else if (koşul) { ... } else { ... }
// ============================================================

static class IfElseOrnek
{
    // ----------------------------------------------------------
    // DEMO
    // ----------------------------------------------------------
    public static void Demo()
    {
        Console.WriteLine("=== IF - ELSE ===");

        int[] puanlar = { 95, 83, 72, 65, 55, 42, 28 };

        Console.WriteLine("  Puan  | UZUN | ORTA | KISA");
        Console.WriteLine("  ------|------|------|-----");

        foreach (int puan in puanlar)
        {
            Console.WriteLine(
                $"  {puan,5} | {HarfNotuUzun(puan),4} | {HarfNotuOrta(puan),4} | {HarfNotuKisa(puan),4}");
        }

        Console.WriteLine();
    }
    // ----------------------------------------------------------
    // UZUN VERSİYON — Harf notu hesaplama, her dal açıklamalı
    // ----------------------------------------------------------
    public static string HarfNotuUzun(int puan)
    {
        string harf;

        // 90 ve üzeri: AA
        if (puan >= 90)
        {
            harf = "AA";
        }
        // 80-89 arası: BA
        else if (puan >= 80)
        {
            harf = "BA";
        }
        // 70-79 arası: BB
        else if (puan >= 70)
        {
            harf = "BB";
        }
        // 60-69 arası: CB
        else if (puan >= 60)
        {
            harf = "CB";
        }
        // 50-59 arası: CC
        else if (puan >= 50)
        {
            harf = "CC";
        }
        // 40-49 arası: DC (şartlı geçer)
        else if (puan >= 40)
        {
            harf = "DC";
        }
        // 40'ın altı: FF (kalır)
        else
        {
            harf = "FF";
        }

        return harf;
    }

    // ----------------------------------------------------------
    // ORTA VERSİYON — Aynı mantık, daha öz yazım
    // ----------------------------------------------------------
    public static string HarfNotuOrta(int puan)
    {
        if (puan >= 90) return "AA";
        if (puan >= 80) return "BA";
        if (puan >= 70) return "BB";
        if (puan >= 60) return "CB";
        if (puan >= 50) return "CC";
        if (puan >= 40) return "DC";
        return "FF";
    }

    // ----------------------------------------------------------
    // KISA VERSİYON — Ternary (üçlü) operatör zinciri
    //  koşul ? doğruysa : yanlışsa
    // ----------------------------------------------------------
    public static string HarfNotuKisa(int p) =>
        p >= 90 ? "AA" :
        p >= 80 ? "BA" :
        p >= 70 ? "BB" :
        p >= 60 ? "CB" :
        p >= 50 ? "CC" :
        p >= 40 ? "DC" : "FF";

}
