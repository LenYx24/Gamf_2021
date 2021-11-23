using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _2f
{
    class F2
    {
        public static void output(){
            Console.WriteLine("-----------------");
            Console.WriteLine("2");
            listafeltolt();
            main();
            // A
            massalhangzo maxmas = ms[0];
            for (int i = 1; i < ms.Count; i++)
            {
                if(maxmas.szam < ms[i].szam) maxmas = ms[i];
            }
            Console.WriteLine($"a: Legtöbbet előforduló mássalhangzó: {maxmas.szam}");
            // B és C
            gyakoriszo maxgyak = gyakoriszavak[0];
            for (int i = 1; i < gyakoriszavak.Count; i++)
            {
                if(maxgyak.szam < gyakoriszavak[i].szam){
                    maxgyak = gyakoriszavak[i];
                    Console.WriteLine($"szó: {maxgyak.szo}, szám: {maxgyak.szam}");
                }
            }
            Console.WriteLine($"Legtöbbet előforduló szó: {maxgyak.szo}:{maxgyak.szam}");
        }
        public static void listafeltolt(){
            for (int i = 0; i < massal.Length; i++)
            {
                ms.Add(new massalhangzo(massal[i]));
            }
        }
        // A
        public static List<massalhangzo> ms = new List<massalhangzo>();
        public class massalhangzo{
            public int szam = 0;
            public string neve;
            public massalhangzo(string neve){
                this.neve = neve;
            }
        }
        // B és C
        public class gyakoriszo{
            public int szam = 1;
            public string szo;
            public gyakoriszo(string szo){
                this.szo = szo;
            }
        }
        public static List<gyakoriszo> gyakoriszavak = new List<gyakoriszo>();
        public static string[] massal = { 
            "B","C","CS","D","DZ","DZS","F","G","GY","H","J","K","L","M","N","NY","P","R","S","SZ","T","TY","V","Z","ZS"
        };
        public static void main(){
            int[] gyakmassal = new int[massal.Length];
            StreamReader reader = new StreamReader("szoveg2.txt");
            while(!reader.EndOfStream){
                string[] data = reader.ReadLine().Split(" ");
                for(int i = 0; i < data.Length;i++){
                    // A
                    string szo = data[i];
                    for (int j = 0; j < szo.Length; j++)
                    {
                        int ind = -1;
                        if(j < szo.Length - 2 && szo.Substring(j,3) == "DZS"){
                            ind = ms.FindIndex(p => p.neve == "DZS");
                            j+=2;
                        }
                        else if(j < szo.Length - 1){
                            string[] ketszamjegyu = {"CS","DZ","GY","NY","SZ","TY","ZS"};
                            foreach(string k in ketszamjegyu){
                                if(k == szo.Substring(j,2)){
                                    ind = ms.FindIndex(p => p.neve == k);
                                    j+=1;
                                    break;
                                }
                            }
                        }
                        if(ind == -1){
                            string[] egyszamjegyu = massal.Where(c => c.Length < 2).ToArray();
                            foreach(string k in egyszamjegyu){
                                if(k == szo[j].ToString()){
                                    ind = ms.FindIndex(p => p.neve == k);
                                    break;
                                }
                            }
                        }
                        if(ind != -1){
                            ms[ind].szam++;
                        }
                    }
                    // B és C
                    if(szo.Length >= 6){
                        int ind = gyakoriszavak.FindIndex(p => p.szo == szo);
                        if(ind == -1){
                            gyakoriszavak.Add(new gyakoriszo(szo));
                        }
                        else{
                            gyakoriszavak[ind].szam++;
                        }
                    }
                }
            }
            reader.Close();
        }
    }
}
