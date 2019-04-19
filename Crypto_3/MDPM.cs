using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_3
{

    public enum Language { Rus, Eng };

    class MDPM
    {

        public string Origin;
        public string Key;
        public string Crypt;
        char[] Letter;
        char[] Gamma;
        char[] Result;
        bool Rus, Eng;
        
        
        List<string> crypt = new List<string>();
        List<char> Check = new List<char>();

        Dictionary<char, string> Table;
        Dictionary<string, int> alphavite;

        
        Language lang;

         public MDPM(string original, string key,  bool Rus, bool Eng)
         {
             this.Origin = original;
             this.Key = key;
             this.lang = Rus ? Language.Rus : Language.Eng; // Исправить в конструкторе bool на Language
            
             Initialization();
         }


         public void Initialization()
         {
             if (lang == Language.Eng)
             {
                 Table = new Dictionary<char, string>(33);
                 alphavite = new Dictionary<string, int>(33);

                 Table.Add('a',"aa");
                 Table.Add('b', "ba");
                 Table.Add('c', "ca");
                 Table.Add('d', "da");
                 Table.Add('e', "ea");
                 Table.Add('f', "ab");
                 Table.Add('g', "bb");
                 Table.Add('h', "cb");
                 Table.Add('i', "db");
                 Table.Add('k', "eb");
                 Table.Add('l', "ca");
                 Table.Add('m', "cb");
                 Table.Add('n', "cc");
                 Table.Add('o', "cd");
                 Table.Add('p', "ce");
                 Table.Add('q', "da");
                 Table.Add('r', "db");
                 Table.Add('s', "dc");
                 Table.Add('t', "dd");
                 Table.Add('u', "de");
                 Table.Add('v', "ea");
                 Table.Add('w', "eb");
                 Table.Add('x', "ec");
                 Table.Add('y', "ed");
                 Table.Add('z', "ee");
                 

                 Table.Add('.', ".?");
                 Table.Add(',', ",?");
                 Table.Add('!', "!?");
                 Table.Add('?', ".:");
                 Table.Add(':', ",:");
                 Table.Add(';', "!:");
                 Table.Add('-', ".;");
                 Table.Add(' ', "");


                 alphavite.Add("a", 0);
                 alphavite.Add("b", 1);
                 alphavite.Add("c", 2);
                 alphavite.Add("d", 3);
                 alphavite.Add("e", 4);
                 alphavite.Add("f", 5);
                 alphavite.Add("g", 6);
                 alphavite.Add("h", 7);
                 alphavite.Add("i", 8);
                 alphavite.Add("j", 9);
                 alphavite.Add("k", 10);
                 alphavite.Add("l", 11);
                 alphavite.Add("m", 12);
                 alphavite.Add("n", 13);
                 alphavite.Add("o", 14);
                 alphavite.Add("p", 15);
                 alphavite.Add("q", 16);
                 alphavite.Add("r", 17);
                 alphavite.Add("s", 18);
                 alphavite.Add("t", 19);
                 alphavite.Add("u", 20);
                 alphavite.Add("v", 21);
                 alphavite.Add("w", 22);
                 alphavite.Add("x", 23);
                 alphavite.Add("y", 24);
                 alphavite.Add("z", 25);

                 alphavite.Add(".", 26);
                 alphavite.Add(",", 27);
                 alphavite.Add("!", 28);
                 alphavite.Add("?", 29);
                 alphavite.Add(":", 30);
                 alphavite.Add(";", 31);
                 alphavite.Add("-", 32);
                 alphavite.Add(" ", 33);

                 
                 
             }
             if (lang == Language.Rus)
             {
                  Table = new Dictionary<char, string>(41);
                  alphavite = new Dictionary<string, int>(40);

                 Table.Add('а', "аа");
                 Table.Add('б', "ба");
                 Table.Add('в', "ва");
                 Table.Add('г', "га");
                 Table.Add('д', "да");
                 Table.Add('е', "еа");
                 Table.Add('ё', "аб");
                 Table.Add('ж', "бб");
                 Table.Add('з', "вб");
                 Table.Add('и', "гб");
                 Table.Add('й', "дб");
                 Table.Add('к', "еб");
                 Table.Add('л', "ав");
                 Table.Add('м', "бв");
                 Table.Add('н', "вв");
                 Table.Add('о', "гв");
                 Table.Add('п', "дв");
                 Table.Add('р', "ев");
                 Table.Add('с', "аг");
                 Table.Add('т', "бг");
                 Table.Add('у', "вг");
                 Table.Add('ф', "гг");
                 Table.Add('х', "дг");
                 Table.Add('ц', "ег");
                 Table.Add('ч', "ад");
                 Table.Add('ш', "бд");
                 Table.Add('щ', "вд");
                 Table.Add('ъ', "гд");
                 Table.Add('ы', "дд");
                 Table.Add('ь', "ед");
                 Table.Add('э', "ае");
                 Table.Add('ю', "бе");
                 Table.Add('я', "ве");
               

                 Table.Add('.', ".?");
                 Table.Add(',', ",?");
                 Table.Add('!', "!?");
                 Table.Add('?', ".:");
                 Table.Add(':', ",:");
                 Table.Add(';', "!:");
                 Table.Add('-', ".;");
                 Table.Add(' ', "");



                 alphavite.Add("а", 0);
                 alphavite.Add("б", 1);
                 alphavite.Add("в", 2);
                 alphavite.Add("г", 3);
                 alphavite.Add("д", 4);
                 alphavite.Add("е", 5);
                 alphavite.Add("ё", 6);
                 alphavite.Add("ж", 7);
                 alphavite.Add("з", 8);
                 alphavite.Add("и", 9);
                 alphavite.Add("й", 10);
                 alphavite.Add("к", 11);
                 alphavite.Add("л", 12);
                 alphavite.Add("м", 13);
                 alphavite.Add("н", 14);
                 alphavite.Add("о", 15);
                 alphavite.Add("п", 16);
                 alphavite.Add("р", 17);
                 alphavite.Add("с", 18);
                 alphavite.Add("т", 19);
                 alphavite.Add("у", 20);
                 alphavite.Add("ф", 21);
                 alphavite.Add("х", 22);
                 alphavite.Add("ц", 23);
                 alphavite.Add("ч", 24);
                 alphavite.Add("ш", 25);
                 alphavite.Add("щ", 26);
                 alphavite.Add("ъ", 27);
                 alphavite.Add("ы", 28);
                 alphavite.Add("ь", 29);
                 alphavite.Add("э", 30);
                 alphavite.Add("ю", 31);
                 alphavite.Add("я", 32);

                 alphavite.Add(".", 33);
                 alphavite.Add(",", 34);
                 alphavite.Add("!", 35);
                 alphavite.Add("?", 36);
                 alphavite.Add(":", 37);
                 alphavite.Add(";", 38);
                 alphavite.Add("-", 39);
                 alphavite.Add(" ", 40);


                 
             }


         }
            
            public string MD()
            {
                Letter = Origin.ToCharArray();

                for (int i = 0; i < Letter.Length; i++)
                {
                   
                    Check.Add(Letter[i]);
                }

                for (int i = 0; i < Letter.Length; i++)
                {
                    
                    foreach (char key in Table.Keys)
                    {
                        if (Check[i] == key)
                        {
                            crypt.Add(Table[key].ToString());
                        }

                    }

                }

                for (int i = 0; i < Letter.Length; i++)
                {
                    Crypt += crypt[i];
                }

                return Crypt;
            }

       

        public string Spaces()
        {
            Result = Crypt.ToCharArray();
            string ResultSpace = "";

            for (int i = 0; i < Result.Length; i++)
            {
                if (i % 5 == 0)
                    ResultSpace += ' ';
                ResultSpace += Result[i];
            }

            return ResultSpace;
        }


        }
    }

