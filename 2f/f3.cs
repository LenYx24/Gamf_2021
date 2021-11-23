using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _2f
{
    class F3
    {
        static List<szamRendszer> szam1Tizesben = new List<szamRendszer>();
        static List<szamRendszer> szam2Tizesben = new List<szamRendszer>();

        class szamRendszer {
            public long szam { get; set; }
            public int szr { get; set; }
            public szamRendszer(long szam, int szr)
            {
                this.szam = szam;
                this.szr = szr;
            }
        }
        public static void output(){
            Console.WriteLine("-----------------");
            Console.WriteLine("3");
            string szam1 = "110a10101";
            string szam2 = "223313020003";

            elsoSzam(szam1);
            masodikSzam(szam2);

            feladat_abc();
        }
        static void elsoSzam(string szam1)
        {
            //Console.WriteLine(szam1 + " átváltva ezekbe a számrendszerekbe:");
            long[] szamrendszer = new long[szam1.Length];
            int szr = 11;

            while (szr < 16)
            {
                for (int i = szam1.Length, j = 0; i > 0; i--, j++)
                {
                    szamrendszer[j] = (long)Math.Pow(szr, (i - 1));
                }
                //Console.WriteLine("\t" + szr + " számrendszer számai:\n\t[" + String.Join(",", szamrendszer) + "]");
                long osszeg = 0;
                for (int i = 0; i < szam1.Length; i++)
                {
                    long szam;
                    if (szam1[i].ToString() == "a")
                    {
                        szam = 10 * szamrendszer[i];
                    }
                    else
                    {
                        szam = long.Parse(szam1[i].ToString()) * szamrendszer[i];
                    }
                    osszeg += szam;
                }
                //Console.WriteLine("\tTizes számrendszerben: " + osszeg + "\n");
                szam1Tizesben.Add(new szamRendszer(osszeg, szr));
                szr++;
            }
        }

        static void masodikSzam(string szam2)
        {
            //Console.WriteLine(szam2 + " átváltva ezekbe a számrendszerekbe:");
            long[] szamrendszer = new long[szam2.Length];
            int szr = 4;

            while (szr < 16)
            {
                for (int i = szam2.Length, j = 0; i > 0; i--, j++)
                {
                    szamrendszer[j] = (long)Math.Pow(szr, i - 1);
                }
                //Console.WriteLine("\t" + szr + " számrendszer számai:\n\t[" + String.Join(",", szamrendszer) + "]");
                long osszeg = 0;
                for (int i = 0; i < szam2.Length; i++)
                {
                    long szam = long.Parse(szam2[i].ToString()) * szamrendszer[i];
                    osszeg += szam;
                }
                //Console.WriteLine("\tTizes számrendszerben: " + osszeg + "\n");
                szam2Tizesben.Add(new szamRendszer(osszeg, szr));
                szr++;
            }
        }

        static void feladat_abc()
        {
            for (int i = 0; i < szam1Tizesben.Count; i++)
            {
                for (int j = 0; j < szam2Tizesben.Count; j++)
                {
                    if (szam1Tizesben[i].szam == szam2Tizesben[j].szam)
                    {
                        Console.WriteLine("a) A két szám ezt a 10-es számrendszer beli számot jelenti: " + szam1Tizesben[i].szam);
                        Console.WriteLine("b) Az első szám alapszáma: " + szam1Tizesben[i].szr);
                        Console.WriteLine("c) A második szám alapszáma: " + szam2Tizesben[j].szr);
                        break;
                    }
                }
            }
        }
        
    }
}
