/*
                            Adam Asmaca (Hang Man)
          
        Buglar hariç iş görür.
 */

Console.OutputEncoding = System.Text.Encoding.UTF8;


#region Adam resmi
string adamResmi = """
                  O
                 /|\
                 / \
    """;
Console.WriteLine(adamResmi);

#endregion

Random rnd = new Random();

int kelimeSec = rnd.Next(1, 6);

#region kelimeler
string kelime;
switch (kelimeSec)
{
    case 1:
        kelime = "kulaklik";
        break;
    case 2:
        kelime = "bardak";
        break;
    case 3:
        kelime = "cüzdan";
        break;
    case 4:
        kelime = "anahtarlik";
        break;
    case 5:
        kelime = "saat";
        break;
    default:
        kelime = "";
        Console.WriteLine("Hatalı");
        break;
}
#endregion


int kelimeUzunluk = kelime.Length;
int hakSayisi = 10;

Console.WriteLine($"Kelime {kelimeUzunluk} harften oluşmaktadır.");
Console.WriteLine("Kalan tahmin hakkınız: " + hakSayisi);

for (int i = 0; i < kelimeUzunluk; i++)
{
    Console.Write("_ ");

}


Console.WriteLine();


bool kazandiMi = false;
List<char> dogruTahmins = new List<char>();

baslangic:
Console.WriteLine();


Console.Write("\r\nHarf Tahmininiz: ");
char tahminHarf = Convert.ToChar(Console.ReadLine());


hakSayisi--;
Console.Write("Kalan tahmin hakkınız: " + hakSayisi);


if (hakSayisi == 0)
{
    goto winLose;
}

#region Kelimeyi tahmin etme
if (hakSayisi < 7)
{
    Console.Write("\r\n Kelimeyi tahmin etmek ister misiniz? Eğer tahmininiz başarısız olursa hakkınız 0'da düşürülüp oyunu kaybedeceksiniz... (e/h): ");
    char kelimeTahminSorgu = Convert.ToChar(Console.ReadLine());
    if (kelimeTahminSorgu == 'e')
    {
        string kelimeTahmin;

        Console.Write("Tahmininiz: ");
        kelimeTahmin = Console.ReadLine();
        kelimeTahmin = kelimeTahmin.ToLower();

        if (kelimeTahmin == kelime)
        {

            kazandiMi = true;
            goto winLose;

        }
        else
        {
            kazandiMi = false;
            goto winLose;
        }
    }
}
#endregion

#region Harf tahmin etme
if (kelime.Contains(tahminHarf))
{
    Console.WriteLine("\r\n  Doğru!");
    if (!dogruTahmins.Contains(tahminHarf))
    {
        dogruTahmins.Add(tahminHarf);
    }

    Console.Write("\r\nDoğru tahminleriniz: ");

    foreach (char d in dogruTahmins)
    {
        Console.Write(d + ", ");
    }

    Console.WriteLine();

    foreach (char c in kelime)
    {
        if (c == tahminHarf)
        {
            Console.Write(c + " ");
        }
        else
        {
            Console.Write("_ ");
        }
    }
    goto baslangic;

}
else
{
    Console.WriteLine("\r\nGirdiğiniz harf kelimede mevcut değil lütfen tekrar deneyin..");
    goto baslangic;
}
#endregion

#region win / lose kontrolü
winLose:
if (kazandiMi)
{
    Console.WriteLine("Doğru bildiniz! Kelime: " + kelime);
}
else
{
    Console.WriteLine("\r\n Tahmin hakkınız kalmadı kaybettiniz.");
    Console.WriteLine("\r\n Kelime: " + kelime);
}
#endregion

Console.ReadKey();