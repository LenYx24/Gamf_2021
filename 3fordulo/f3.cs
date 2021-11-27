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
            Console.WriteLine("--------------------");
            feladatA(15, true);
            feladatB();
            feladatC();
        }

        /*    
            Első feladat: Hány ilyen pitagoraszi számhármas van.
            Kikötés: a = 15; b <= 1.000.000
        */

        static void feladatA(ulong a, bool giveOutput) {
            for (ulong b = 1; b < 1000000; b++) {
                ulong cnegyzet = a*a+b*b;
                if (debug) Console.WriteLine("Sqr:" + cnegyzet.ToString());

                double c = Math.Sqrt(cnegyzet);
                if (debug) Console.WriteLine("Sqrt: " + c.ToString());

                ulong d;
                if (debug) Console.WriteLine(a.ToString() + "^2 * " + b.ToString() + "^2 = " + cnegyzet + "\n----");

                if (ulong.TryParse(c.ToString(), out d)) {
                    harmasok.Add(new SzamHarmas(a, b, d));
                }
            }
            if (giveOutput) Console.WriteLine("-----------------\nA szám".PadRight(20) + "B szám".PadRight(20) + "C szám".PadRight(20));
            for (int b = 0; b < harmasok.Count; b++) {
                if (giveOutput) Console.WriteLine(harmasok[b].a.ToString().PadRight(20) + harmasok[b].b.ToString().PadRight(20) + harmasok[b].c.ToString().PadRight(20));
            }
            if (giveOutput) Console.WriteLine("-----------------\nPitagoraszi számhármasok: ".PadRight(20) + harmasok.Count);
        }

        /*
            Második feladat: Pitagoraszi hármasok számainak összeszorzása.
            Kérdés: Melyik a legnagyobb szorzat ami még kisebb mint 1.000.000
        */

        static void feladatB() {
            int legnagyobb = 0;
            for (int i = 0; i < harmasok.Count; i++) {
                ulong szorzat = 0;
                if (i < harmasok.Count) {
                    szorzat = harmasok[i].a * harmasok[i].b * harmasok[i].c;
                }
                if (debug) Console.WriteLine((i+1) + ". szorzat: " + szorzat + "(" + harmasok[i].a + " * " + harmasok[i].b + " * " + harmasok[i].c + ")");
                if (legnagyobb < (int)szorzat) {
                    legnagyobb = (int)szorzat;
                }
            }
            Console.WriteLine("-----------------\nLegnagyobb számhármas szozata: " + legnagyobb);
        }

        /*
            Harmadik feladat: Keress olyan pitagoraszi hármasokat amelyek oldalainak összege 2400.
            Kérdés: Hány ilyen hármas van?
            Kikötés: Ugyan azok a számok különböző sorrendben nem érvényesek.
        */

        static void feladatC() {
            int counter = 0;
            List<ulong> aSzamok = new List<ulong>();
            List<ulong> bSzamok = new List<ulong>();
            List<ulong> cSzamok = new List<ulong>();
            for (ulong a = 1; a < 2401; a++) {
                for (ulong b = 1; b < 2401; b++) {
                    ulong negyzet = a*a + b*b;

                    double c = Math.Sqrt(negyzet);

                    ulong d;
                    if (ulong.TryParse(c.ToString(), out d)) {
                        if (a+b+c == 2400 && !aSzamok.Contains(a) && !bSzamok.Contains(b) && !cSzamok.Contains(d)) {
                            if (debug) Console.WriteLine(a.ToString().PadRight(20) + b.ToString().PadRight(20) + c.ToString().PadRight(20) + (a+b+c).ToString());
                            counter++;
                            aSzamok.Add(a);
                            bSzamok.Add(b);
                            cSzamok.Add(d);
                        }
                    }
                }
            }
            Console.WriteLine("-----------------\nSzámhármasok: " + counter);
        }
    }
}
