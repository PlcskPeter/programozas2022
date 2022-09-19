using System.Text;

feladat a = new feladat();

class feladat
{
    public feladat()
    {
        f1();
        f2();
        f3();
        f4();
        f5();
        f6();
    }
    List<adatok> triatlon = new List<adatok>();
    void f1()
    {
        string[] sorok = File.ReadAllLines("eredmenyek.txt", Encoding.Default);
        for (int i = 0; i < sorok.Length; i++)
        {
            triatlon.Add(new adatok(sorok[i]));
        }
    }

    void f2()
    {
        Console.WriteLine("2. feladat: A versenyt {0} versenyző fejezte be.", triatlon.Count);
    }

    void f3()
    {
        int junior = 0;
        for (int i = 0; i < triatlon.Count; i++)
        {
            if (triatlon[i].eletkorKat == "elit junior")
            {
                junior++;
            }
        }
        Console.WriteLine("3. feladat: Versenyzők száma az \"elit junior\" kategóriában: {0} fő", junior);
    }

    void f4()
    {
        double osszEletkor = 0;
        for (int i = 0; i < triatlon.Count; i++)
        {
            osszEletkor += 2014 - triatlon[i].szuldatum;
        }

        Console.WriteLine("4. feladat: Átlagéletkor: {0:0.0} év", osszEletkor / triatlon.Count);
    }

    void f5()
    {
        Console.Write("5. feladat: Kérek egy kategóriát: ");
        string kategoria = Console.ReadLine();
        bool volt = false;
        Console.Write("\tRajtszám(ok): ");
        for (int i = 0; i < triatlon.Count; i++)
        {
            if (kategoria == triatlon[i].eletkorKat)
            {
                Console.Write(triatlon[i].rajtszam + " ");
                volt = true;
            }
        }
        Console.WriteLine();
        if (!volt)
        {
            Console.WriteLine("Nincs ilyen kategória");
        }
    }

    void f6()
    {
        int index = 0;
        for (int i = 0; i < triatlon.Count; i++)
        {
            if (triatlon[i].nem == "n")
            {
                if (triatlon[index].osszIdo() > triatlon[i].osszIdo())
                {
                    index = i;
                }
            }
        }
        Console.WriteLine("6. feladat: A legjobb időt {0} érte el", triatlon[index].nev);
    }
}


class adatok
{
    public string nev, nem, eletkorKat, uszas, elsoDepo, kerekpar, masodikDepo, futas;
    public int szuldatum, rajtszam;
    public adatok(string sor)
    {
        string[] vag = sor.Split(";");
        nev = vag[0];
        szuldatum = Convert.ToInt32(vag[1]);
        rajtszam = Convert.ToInt32(vag[2]);
        nem = vag[3];
        eletkorKat = vag[4];
        uszas = vag[5];
        elsoDepo = vag[6];
        kerekpar = vag[7];
        masodikDepo = vag[8];
        futas = vag[9];
    }

    int mp(string ido)
    {
        string[] vag = ido.Split(":");
        return Convert.ToInt32(vag[0]) * 60 * 60 + Convert.ToInt32(vag[1]) * 60 + Convert.ToInt32(vag[2]);
    }

    public int osszIdo()
    {
        return mp(uszas) + mp(elsoDepo) + mp(kerekpar) + mp(masodikDepo) + mp(futas);
    }
}