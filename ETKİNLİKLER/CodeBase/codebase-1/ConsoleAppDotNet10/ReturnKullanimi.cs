// ============================================================
//  RETURN — FONKSİYONU YARIDA KES
//
//  return iki şey yapar:
//    1) Fonksiyondan ÇIKAR (altındaki kodlar çalışmaz)
//    2) Bir değer GERİ DÖNDÜRÜR
//
//  Erken return (early return) sayesinde gereksiz iç içe
//  if-else bloklarından kaçınılır ve kod okunabilir olur.
// ============================================================

using System;
using System.Linq;

static class ReturnKullanimi
{
    // ----------------------------------------------------------
    // DEMO
    // ----------------------------------------------------------
    public static void Demo()
    {
        Console.WriteLine("=== RETURN — ERken ÇIKIŞ ===");

        string?[] testSifreler = { null, "", "abc", "abcdef", "abc123" };

        foreach (string? sifre in testSifreler)
        {
            string gosterim = sifre is null ? "(null)" : $"\"{sifre}\"";
            Console.WriteLine($"  {gosterim,-12} → [ORTA] {SifreKontrolOrta(sifre)}");
        }

        Console.WriteLine("\n  Boş dizi:"); EkranaYazUzun([]);
        Console.WriteLine("  Dolu dizi:"); EkranaYazUzun([3, 1, 4, 1, 5, 9]);

        Console.WriteLine();
    }
    // ----------------------------------------------------------
    // UZUN VERSİYON — Return yok, tek büyük if-else bloğu
    //  Şifre doğrulama: boş mu? kısa mı? geçerli mi?
    // ----------------------------------------------------------
    public static string SifreKontrolUzun(string? sifre)
    {
        string mesaj;

        if (sifre == null)
        {
            mesaj = "Hata: Şifre null olamaz.";
        }
        else
        {
            if (sifre.Length == 0)
            {
                mesaj = "Hata: Şifre boş olamaz.";
            }
            else
            {
                if (sifre.Length < 6)
                {
                    mesaj = "Hata: Şifre en az 6 karakter olmalı.";
                }
                else
                {
                    if (!sifre.Any(char.IsDigit))
                    {
                        mesaj = "Hata: Şifre en az bir rakam içermeli.";
                    }
                    else
                    {
                        mesaj = "Şifre geçerli!";
                    }
                }
            }
        }

        return mesaj;
    }

    // ----------------------------------------------------------
    // ORTA VERSİYON — Erken return (early return) kullanımı
    //  Her hata durumunda hemen return yaparız.
    //  Koşullar olumsuz yönden yazılır → "guard clause" deseni.
    // ----------------------------------------------------------
    public static string SifreKontrolOrta(string? sifre)
    {
        // Geçersiz durumlarda hemen çık
        if (sifre == null) return "Hata: Şifre null olamaz.";
        if (sifre.Length == 0) return "Hata: Şifre boş olamaz.";
        if (sifre.Length < 6) return "Hata: Şifre en az 6 karakter olmalı.";
        if (!sifre.Any(char.IsDigit)) return "Hata: Şifre en az bir rakam içermeli.";

        // Buraya ancak her şey geçerliyse ulaşılır
        return "Şifre geçerli!";
    }

    // ----------------------------------------------------------
    // KISA VERSİYON — Ternary zinciri
    // ----------------------------------------------------------
    public static string SifreKontrolKisa(string? s) =>
        s is null ? "Hata: null." :
        s.Length == 0 ? "Hata: boş." :
        s.Length < 6 ? "Hata: çok kısa." :
        !s.Any(char.IsDigit) ? "Hata: rakam yok." :
                             "Geçerli!";

    // ----------------------------------------------------------
    // EK ÖRNEK: return void — değersiz erken çıkış
    // ----------------------------------------------------------
    public static void EkranaYazUzun(int[] dizi)
    {
        // Dizi boşsa devam etme, erken çık (void fonksiyonda return değer almaz)
        if (dizi == null || dizi.Length == 0)
        {
            Console.WriteLine("  Dizi boş, yazdırılacak eleman yok.");
            return;   // ← buradan çıkar, aşağısı çalışmaz
        }

        foreach (int eleman in dizi)
        {
            Console.Write(eleman + " ");
        }
        Console.WriteLine();
    }


}
