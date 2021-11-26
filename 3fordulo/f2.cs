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
        /* 
            Hogy kevesebb időbe teljen megkeresni, hogy egy szónak van-e polindróm alakja, ezért csak azokkal ellenőrzi
            le, amelynek a kezdőbetűje megegyezik a szóval
            PL: teve:evet
                a teve szó fordított alakját nem nézi meg, hogy egyezik e bármely másik szóval, hanem csak azokkal
                amik e betűvel kezdődnek
            Ezért tárolom el, hogy melyik betű a listában melyik indextől kezdődik
        */
        public class letterIndex{
            public int startIndex {get; set;}
            public int endIndex {get; set;}
            public char letter {get; set;}
            public letterIndex(int startIndex, int endIndex, char letter){
                this.startIndex = startIndex;
                this.endIndex = endIndex;
                this.letter = letter;
            }
        }
        public static List<string> words = new List<string>();
        public static string[] vowels = {"A","E","I","O","U"};
        public static int b = 0;
        public static List<letterIndex> partsInWords = new List<letterIndex>();

        public static void output(){
            Console.WriteLine("--------------------");
            Console.WriteLine("f2");
            main();
            Console.WriteLine($"a: {words.Count}");
            Console.WriteLine($"b: {b}");
            List<string> clista = c();
            Console.WriteLine($"c: {clista.Count}");
            for (int i = 0; i < clista.Count; i++)
            {
                Console.WriteLine($"{clista[i]}");
            }
        }
        // Visszaadja, hogy a words listában melyik indextől kezdődnek és végződnek a letter kezdőbetűs szavak
        public static int[] getIndex(char letter){
            int[] indexes = {-1,-1};
            for(int i = 0; i < partsInWords.Count; i++){
                if(partsInWords[i].letter == letter){
                    indexes[0] = partsInWords[i].startIndex;
                    indexes[1] = partsInWords[i].endIndex;
                    return indexes;
                }
            }
            return indexes;
        }
        public static List<string> c(){
            words.Sort();
            char crLetter = words[0][0];
            int startIndex = 0;
            for (int i = 0; i < words.Count; i++)
            {
                if(words[i][0] != crLetter){
                    partsInWords.Add(new letterIndex(startIndex,i-1,words[i-1][0]));
                    startIndex = i;
                    crLetter = words[i][0];
                }
            }
            // Az a kérdés, hogy hány palindróm van, nem számít, ha ugyanabból több van
            List<string> palindromok = new List<string>(); 
            for (int i = 0; i < words.Count; i++)
            {
                if(words[i].Length >= 2 && !palindromok.Contains(words[i])){
                    string reverse = Reverse(words[i]);
                    if(words[i] == reverse){
                        palindromok.Add(words[i]);
                    }
                    else{
                        int[] indexes = getIndex(reverse[0]);
                        if(indexes[0] == -1) continue;
                        for (int j = indexes[0]; j <= indexes[1]; j++)
                        {
                            if(words[j] == reverse){ // Magát a szót és a fordítottját is hozzáadom, mert ez két pontot ér
                                palindromok.Add(words[i]);
                                palindromok.Add(reverse);
                            }
                        }
                    }
                }
            }
            return palindromok;
        }
        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
        public static void main(){
            StreamReader reader = new StreamReader("szoveg2.txt");
            while(!reader.EndOfStream){
                string[] data = reader.ReadLine().Split(" ");
                for(int i = 0; i < data.Length;i++){
                    string szo = data[i];
                    if(Regex.IsMatch(szo, @"^[A-Z0-9]+$")){ // Space karakterek ne legyenek
                        // A
                        int ind = words.FindIndex(p => p == szo);
                        if(ind == -1){
                            words.Add(szo);
                        }
                        // B
                        if(szo.Contains("E") && !szo.Contains("A") && !szo.Contains("I") && !szo.Contains("O") && !szo.Contains("U")){
                            b++;
                        }
                    }
                }
            }
            reader.Close();
        }
    }
}