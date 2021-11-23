using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _2f
{
    class F1
    {
        static char[] betuk = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
        static char[] Cbetuk = "gqhvtyacnzlkmirpbosuxdefjw".ToCharArray();
        public static void output(){
            Console.WriteLine("-----------------");
            Console.WriteLine("1");

            Console.WriteLine($"példa:{titkosit(betuk,"prim")}");
            Console.WriteLine($"a:{titkosit(betuk,"program")}");

            Console.WriteLine($"Teszt1(phav):{dekodol(betuk,"phav")}");
            Console.WriteLine($"Teszt2(phgvysn):{dekodol(betuk,"phgvysn")}");
            Console.WriteLine($"b:{dekodol(betuk,"xrvzibtwzzsduvpygpziluequciojomx")}");

            Console.WriteLine($"Teszt1(prim):{titkosit(Cbetuk,"prim")}");
            Console.WriteLine($"Teszt1(pthg):{dekodol(Cbetuk,"pthg")}");
            Console.WriteLine($"Teszt2(program):{titkosit(Cbetuk,"program")}");
            Console.WriteLine($"Teszt2(ptaspdu):{dekodol(Cbetuk,"ptaspdu")}");

            Console.WriteLine($"c:{dekodol(Cbetuk,"tutgabjbavhwnoqfecvxbqvbddkpsqlw")}");
        }
        static string titkosit(char[] betukeszlet, string text){
            int[] kodok = new int[text.Length];
            // 1.lépés
            for (int i = 0; i < text.Length; i++)
            {
                kodok[i] = Array.IndexOf(betukeszlet, text[i])+1;
            }
            // 2.lépés és 3.lépés
            for (int i = kodok.Length-1; i > 0; i--)
            {
                if(kodok[i] + kodok[i-1] > 26){
                    kodok[i] += kodok[i-1] - 26;
                }
                else{
                    kodok[i] += kodok[i-1];
                }
            }
            // 4.lépés
            string[] str = new string[text.Length];
            for (int i = 0; i < kodok.Length; i++)
            {
                str[i] = betukeszlet[kodok[i]-1].ToString();
            }
            return String.Join(' ',str).Replace(" ","");
        }


        static string dekodol(char[] betukeszlet, string text){
            int[] kodok = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                kodok[i] = Array.IndexOf(betukeszlet, text[i])+1;
            }
            for (int i = 1; i < text.Length; i++)
            {
                if(kodok[i] - kodok[i-1] < 1)
                    kodok[i] = kodok[i] - kodok[i-1] + 26;
                else
                    kodok[i] -= kodok[i-1];
            }
            string[] str = new string[text.Length]; 
            for (int i = 0; i < text.Length; i++)
            {
                str[i] = betukeszlet[kodok[i]-1].ToString();
            }
            return String.Join(' ',str).Replace(" ","");
        }
    }
}
