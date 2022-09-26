feladat a = new feladat();

class feladat
{
    List<adatok> adasok = new List<adatok>();
    public feladat()
    {
        f2();
        f3();
        f4();
    }

    void f2()
    {
        string[] sorok = File.ReadAllLines("cb.txt");
        for (int i = 1; i < sorok.Length; i++)
        {
            adasok.Add(new adatok(sorok[i]));
        }
    }

    void f3()
    {
        Console.WriteLine("3. feladat: Bejegyzések száma: {0} db", adasok.Count);
    }

    void f4()
    {
        bool volt = false;
        for (int i = 0; i < adasok.Count; i++)
        {
            if (adasok[i].adasDb == 4)
            {
                volt = true;
            }
            break;
        }
        if (volt)
        {
            Console.WriteLine("4. feladat: Volt négy adást indító sofőr");
        }
    }

class adatok
{
    public int ora, perc, adasDb;
    public string nev;
    public adatok(string sor)
    {
        string[] vag = sor.Split(";");
        ora = Convert.ToInt32(vag[0]);
        perc = Convert.ToInt32(vag[1]);
        adasDb = Convert.ToInt32(vag[2]);
        nev = vag[3];
    }
}