using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _3f
{
    class F3
    {
        class SzamHarmas {
            public ulong a { get; set; }
            public ulong b { get; set; }
            public ulong c { get; set; }

            public SzamHarmas(ulong a, ulong b, ulong c) {
                this.a = a;
                this.b = b;
                this.c = c;
            }
        }

        static List<SzamHarmas> harmasok = new List<SzamHarmas>();
        static bool debug = false;
        public static void output(){

            /*
            
                Első feladat: Pitagoraszi számhármasok száma, ha a = 15 és b legfejebb = 1000000;
                Második feladat: 
            
            */

            Console.WriteLine("--------------------");
            ulong a = 15;
            for (ulong i = 1; i < 1000000; i++) {
                ulong cnegyzet = a*a+i*i;
                if (debug) Console.WriteLine("Sqr:" + cnegyzet.ToString());

                double c = Math.Sqrt(cnegyzet);
                if (debug) Console.WriteLine("Sqrt: " + c.ToString());

                ulong d;
                if (debug) Console.WriteLine(a.ToString() + "^2 * " + i.ToString() + "^2 = " + cnegyzet + "\n----");

                if (ulong.TryParse(c.ToString(), out d)) {
                    harmasok.Add(new SzamHarmas(a, i, d));
                }
            }
            Console.WriteLine("A szám".PadRight(20) + "B szám".PadRight(20) + "C szám".PadRight(20));
            for (int i = 0; i < harmasok.Count; i++) {
                Console.WriteLine(harmasok[i].a.ToString().PadRight(20) + harmasok[i].b.ToString().PadRight(20) + harmasok[i].c.ToString().PadRight(20));
            }
            Console.WriteLine("Pitagoraszi számhármasok: ".PadRight(20) + harmasok.Count);
        }
    }
}
