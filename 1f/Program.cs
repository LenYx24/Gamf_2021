using System;
using System.Collections.Generic;
using System.Linq;
using debug;
using System.IO;
using System.Text.RegularExpressions;

namespace GAMF
{
    class Program
    {
        /*
        public static List<int> primek;
        static void Main(string[] args)
        {
            primek = primszamok(); // Prímek 10-100000
            primek.RemoveRange(0,4); // Az első négy elemet törölni kell, mert tíznél kisebb számok {2,3,5,7}
            Console.WriteLine($"a: {primek.Count}");
            Console.WriteLine($"b: {primek[primek.Count-1]}");
            Console.WriteLine($"c: {numOfPrimes(szamJegyOsszeadas(primek))}");
        }
        static int numOfPrimes(List<int> list){ // Megadja, hogy egy listában mennyi prím szám van
            int num = list.Count;
            for (int i = 0; i < list.Count; i++)
                if(oszthatoe(list[i])) num--; 
            return num;
        }
        // Az adott lista elemeinek számjegyeit összeadja és ezt az új listát return-öli
        public static List<int> szamJegyOsszeadas(List<int> primeNums){
            List<int> eredmeny = new List<int>();
            for (int i = 0; i < primeNums.Count; i++)
            {
                int result = primeNums[i].ToString().Sum(c => c - '0'); // Összeadom a számjegyeket
                eredmeny.Add(result); // Hozzáadom az összeadott számjegyeket tartalmazó list-hez
            }
            return eredmeny;
        }
        public static List<int> primszamok(){
            List<int> primszmk = new List<int>();
            for (int i = 2; i < 100000; i++)
                if(!oszthatoe(i)) // Ha nem osztható semmivel, akkor prím szám
                    primszmk.Add(i);
            return primszmk;
        }
        public static bool oszthatoe(int szam){
            int x = (int)Math.Floor(Math.Sqrt(szam));
            for (int i = 2; i <= x; ++i)
                if (szam % i == 0) return true;
            return false;
        }
        */
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("szoveg1.txt");
            int ibetuk = 0;
            int mintaszavak = 0;
            int ketbetusek = 0;
            int reg = 0;
            while (!r.EndOfStream)
            {
                string[] szavak = r.ReadLine().Split(' ');
                for (int i = 0; i < szavak.Length; i++)
                {
                    //2. feladat a.rész
                    /*
                    if (szavak[i].Contains('.'))
                    {
                        szavak[i] = szavak[i].Replace('.', ' ').Trim();
                    } else if (szavak[i].Contains(','))
                    {
                        szavak[i] = szavak[i].Replace(',', ' ').Trim();
                    }*/
                    if (szavak[i].Contains('i') || szavak[i].Contains('I'))
                    {
                        ibetuk++;
                    }
                    //2. feladat b.rész
                    Regex res = new Regex(@"i[a-z]{2}an");
                    if(res.IsMatch(szavak[i])) 
                        reg++;
                    //2. feladat c.rész
                    bool ibetu = szavak[i].Contains('i');
                    bool abetu = szavak[i].Contains('a');
                    bool nbetu = szavak[i].Contains('n');
                    if(ibetu && abetu && !nbetu){
                        ketbetusek++;
                    }
                    else if(ibetu && !abetu && nbetu){
                        ketbetusek++;
                    }
                    else if(!ibetu && abetu && nbetu){
                        ketbetusek++;
                    }
                }
            }
            r.Close();
            //2.feladat a.rész
            Console.WriteLine("i száma: " + ibetuk);
            //2.feladat b.rész
            Console.WriteLine("Mintának megfelelő szavak:" + mintaszavak);
            Console.WriteLine("reg:"+reg);
            //2.feladat c.rész
            Console.WriteLine("Szavak amik a 3 betűből kettőt tartalmaznak: " + ketbetusek);
        }
    }
}
