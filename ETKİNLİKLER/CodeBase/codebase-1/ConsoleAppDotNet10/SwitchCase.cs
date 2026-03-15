// ============================================================
//  SWITCH - CASE
//  Bir değişkenin birden fazla olası değerini temiz biçimde ele alır.
//  if-else zinciri yazabilirsiniz ama switch daha okunabilirdir.
// ============================================================

using System;

static class SwitchCaseOrnek
{
    // ----------------------------------------------------------
    // DEMO
    // ----------------------------------------------------------
    public static void Demo()
    {
        Console.WriteLine("=== SWITCH - CASE ===");

        Console.WriteLine("  Gün  | UZUN          | ORTA          | KISA");
        Console.WriteLine("  -----|---------------|---------------|----------");

        for (int i = 1; i <= 8; i++)
        {
            Console.WriteLine($"  {i,4} | {GunAdiUzun(i),-14}| {GunAdiOrta(i),-14}| {GunAdiKisa(i)}");
        }

        Console.WriteLine("\n  Hesap makinesi (switch expression):");
        Console.WriteLine($"    10 + 3  = {Hesapla(10, "+", 3)}");
        Console.WriteLine($"    10 * 3  = {Hesapla(10, "*", 3)}");
        Console.WriteLine($"    10 / 4  = {Hesapla(10, "/", 4)}");

        Console.WriteLine();
    }
    
    // ----------------------------------------------------------
    // UZUN VERSİYON — Klasik switch-case, break ile
    //  Gün numarasına göre gün adını döndür
    // ----------------------------------------------------------
    public static string GunAdiUzun(int gun)
    {
        string ad;

        switch (gun)
        {
            case 1:
                ad = "Pazartesi";
                break;      // ← break olmadan bir sonraki case'e "düşer"!

            case 2:
                ad = "Salı";
                break;

            case 3:
                ad = "Çarşamba";
                break;

            case 4:
                ad = "Perşembe";
                break;

            case 5:
                ad = "Cuma";
                break;

            case 6:
                ad = "Cumartesi";
                break;

            case 7:
                ad = "Pazar";
                break;

            default:                    // hiçbir case uymadıysa
                ad = "Geçersiz gün";
                break;
        }

        return ad;
    }

    // ----------------------------------------------------------
    // ORTA VERSİYON — Return kullanarak break'ten kurtul
    //  + birden fazla case aynı koda yönlendirilir (fall-through)
    // ----------------------------------------------------------
    public static string GunAdiOrta(int gun)
    {
        switch (gun)
        {
            case 1: return "Pazartesi";
            case 2: return "Salı";
            case 3: return "Çarşamba";
            case 4: return "Perşembe";
            case 5: return "Cuma";
            case 6:
            case 7: return "Hafta sonu";   // 6 ve 7 aynı çıktıya yönlendi
            default: return "Geçersiz gün";
        }
    }

    // ----------------------------------------------------------
    // KISA VERSİYON — C# switch expression (C# 8.0+)
    //  Artık switch bir ifadedir, bir değer üretir.
    // ----------------------------------------------------------
    public static string GunAdiKisa(int gun) => gun switch
    {
        1 => "Pazartesi",
        2 => "Salı",
        3 => "Çarşamba",
        4 => "Perşembe",
        5 => "Cuma",
        6 or 7 => "Hafta sonu",
        _ => "Geçersiz gün"    // _ default anlamına gelir
    };

    // ----------------------------------------------------------
    // EK ÖRNEK: string switch — işlem hesaplama
    // ----------------------------------------------------------
    public static double Hesapla(double a, string islem, double b)
    {
        return islem switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" when b != 0 => a / b,   // when ile koşul eklenebilir
            "/" => throw new DivideByZeroException("Sıfıra bölünemez!"),
            _ => throw new ArgumentException($"Bilinmeyen işlem: {islem}")
        };
    }

}
