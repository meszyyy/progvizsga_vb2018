using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace vb2018
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2. feladat
            StreamReader Olvas = new StreamReader("vb2018.txt", Encoding.Default);
            List<Stadion> vb = new List<Stadion>();
            string Fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                vb.Add(new Stadion(Olvas.ReadLine()));
            }
            Olvas.Close();
            #endregion

            #region 3. feladat
            Console.WriteLine($"3. feladat: Stadionok szama: {vb.Count}");
            #endregion

            #region 4. feladat
            int legkevesebbferohely = vb[0].Ferohely;
            for (int i = 0; i < vb.Count; i++)
            {
                if (vb[i].Ferohely < legkevesebbferohely)
                {
                    legkevesebbferohely = vb[i].Ferohely;
                }
            }
            Console.WriteLine("4. feladat: A legkevesebb ferohely:");
            for (int i = 0; i < vb.Count; i++)
            {
                if (vb[i].Ferohely == legkevesebbferohely)
                {
                    Console.WriteLine($"\tVaros: {vb[i].Varos}");
                    Console.WriteLine($"\tStadion neve: {vb[i].nev1}");
                    Console.WriteLine($"\tFerohely: {vb[i].Ferohely}");
                }
            }
            #endregion

            #region 5. feladat
            double osszFerohely = 0;
            for (int i = 0; i < vb.Count; i++)
            {
                osszFerohely += vb[i].Ferohely;
            }
            Console.WriteLine($"5. feladat: Atlagos ferohelyszam: {Math.Round((osszFerohely / vb.Count),1)}");
            #endregion

            #region 6. feladat
            int KetNev = 0;
            for (int i = 0; i < vb.Count; i++)
            {
                if (vb[i].nev2 != "n.a.")
                {
                    KetNev++;
                }
            }
            Console.WriteLine($"6. feladat: Ket neven is ismert stadionok szama: {KetNev}");
            #endregion

            #region 7. feladat
            bool megfeleloVaros = false;
            string BekertVaros = "";
            while (megfeleloVaros == false)
            {
                Console.Write("7. feladat: Kerem a varos nevet: ");
                BekertVaros = Console.ReadLine();
                if (Regex.IsMatch(BekertVaros, @"^[a-zA-Z]{3,}$"))
                {
                    megfeleloVaros = true;
                }
            }
            #endregion

            #region 8. feladat
            bool VoltEMeccs = false;
            for (int i = 0; i < vb.Count; i++)
            {
                if (vb[i].Varos.ToUpper() == BekertVaros.ToUpper())
                {
                    VoltEMeccs = true;
                }
            }
            if (VoltEMeccs == true)
            {
                Console.WriteLine("8. feladat: A megadott varos VB helyszin.");
            }
            else
            {
                Console.WriteLine("8. feladat: A megadott varos nem VB helyszin.");
            }
            #endregion

            #region 9. feladat
            List<string> Varosok = new List<string>();
            for (int i = 0; i < vb.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < Varosok.Count; j++)
                {
                    if (vb[i].Varos == Varosok[j])
                    {
                        SzerepelE = true;
                    }
                }
                if (SzerepelE == false)
                {
                    Varosok.Add(vb[i].Varos);
                }
            }
            Console.WriteLine($"9. feladat: {Varosok.Count} kulonbozo varosban voltak merkozesek.");
            #endregion
            Console.ReadKey();
        }
    }
    class Stadion
    {
        public string Varos;
        public string nev1;
        public string nev2;
        public int Ferohely;

        public Stadion(string AdatSor)
        {
            string[] AdatSorElemek = AdatSor.Split(';');
            this.Varos = AdatSorElemek[0];
            this.nev1 = AdatSorElemek[1];
            this.nev2 = AdatSorElemek[2];
            this.Ferohely = int.Parse(AdatSorElemek[3]);
        }
    }
}
