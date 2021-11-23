using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace _3f
{
    class F2
    {
        public static void output(){
            Console.WriteLine("--------------------");
            Console.WriteLine("f2");
            main();
            // Sorbarendeztem, hogy könnyebb legyen keresni a szavak között/tesztelni
            /*
            List<string> ordered = szavak.OrderBy(q => q).ToList();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}:{ordered[i]}");
            }
            */
            Console.WriteLine($"a: {szavak.Count}");
        }
        public static List<string> szavak = new List<string>();
        public static void main(){
            StreamReader reader = new StreamReader("szoveg2.txt");
            while(!reader.EndOfStream){
                string[] data = reader.ReadLine().Split(" ");
                for(int i = 0; i < data.Length;i++){
                    // A
                    string szo = data[i];
                    if(Regex.IsMatch(szo, @"^[A-Z0-9]+$")){
                        int ind = szavak.FindIndex(p => p == szo);
                        if(ind == -1){
                            szavak.Add(szo);
                        }
                    }
                }
            }
            reader.Close();
        }
    }
}