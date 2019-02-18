using System;
using System.IO;

class Kopiowanie
{
    static void Main()
    {
        // kopiowanie z folderu C:\Dane do "C:\Dane2.
        string skad = @"C:\Dane";
        string dokad = @"C:\Dane2";
        kopiowanieFolderow(skad, dokad, true);
    }

    private static void kopiowanieFolderow(string skad, string dokad, bool czyKopiowacPodkatalogi)
    {
        DirectoryInfo dir = new DirectoryInfo(skad);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Folder Zrodlowy nie istnieje lub nie zostal znaleziony" + skad);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        if (!Directory.Exists(dokad))
        {
            Directory.CreateDirectory(dokad);
        }
 
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string tymczasowaSciezka = Path.Combine(dokad, file.Name);
                file.CopyTo(tymczasowaSciezka, false);
          
        }

   
        if (czyKopiowacPodkatalogi)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tymczasowaSciezka = Path.Combine(dokad, subdir.Name);
                kopiowanieFolderow(subdir.FullName, tymczasowaSciezka, czyKopiowacPodkatalogi);
            }
        }
    }
}