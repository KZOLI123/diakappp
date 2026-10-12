using diakappp;

List<Diak> diakok = new List<Diak>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadLines("eredmenyek.csv").Skip(1))
{
    string[] adatok = sor.Split(';');
    if (adatok.Length != 3)
    {
        hibasSorokSzama++;
        continue;
    }
    string nev = adatok[0].Trim();
    string osztaly = adatok[1].Trim();
    if (!int.TryParse(adatok[2], out int pontszam))
    {
        hibasSorokSzama++;
        continue;
    }
    if(string.IsNullOrWhiteSpace(nev) || string.IsNullOrWhiteSpace(osztaly))
    {
        hibasSorokSzama++;
        continue;
    }
    diakok.Add(new Diak(nev, osztaly, pontszam));
}

Console.WriteLine($"Sikeresen beolvasott diákok száma: {diakok.Count}");
Console.WriteLine($"Hibás sorok száma: {hibasSorokSzama}");
foreach (Diak kiir in diakok)
{
    Console.WriteLine(kiir);
}
