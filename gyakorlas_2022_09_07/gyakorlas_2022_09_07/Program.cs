feladat a = new feladat();
class feladat
{
    public feladat()
    {
        //f1();
        f2();
        f3();
    }

    void f1()
    {
        StreamWriter ir = new StreamWriter("diakok.txt");
        Console.Write("Add meg a diák nevét: ");
        string nev = Console.ReadLine();
        while (nev != "")
        {
            ir.WriteLine(nev);
            Console.Write("Adj meg egy új diák nevét: ");
            nev = Console.ReadLine();
        }
        ir.Close();
    }
    List<adatok> diaklista = new List<adatok>();
    void f2()
    {
        string[] sorok = File.ReadAllLines("diakok.txt");
        for (int i = 0; i < sorok.Length; i++)
        {
            diaklista.Add(new adatok(sorok[i]));
        }
    }

    void f3()
    {
        Random rand = new Random();
        diaklista[0].feladat = Convert.ToString(rand.Next(1, 21));

        Console.WriteLine(diaklista[0].nev, diaklista[0].feladat);
    }
}

class adatok
{
    public string nev;
    public string feladat;
    public adatok(string sor)
    {
        string[] vag = sor.Split(";");
        nev = vag[0];
        feladat = vag[1];
    }
}