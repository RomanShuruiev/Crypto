using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Crypto_3
{
    enum CryptoAlg { Cesar, Viganer, ExchangeTables, FibonaccyGamma, MD, Lattice }
   
    class Crypto 
    {

        Dictionary<string, int> alphavite = new Dictionary<string, int>(39);
        Dictionary<int, string> CodeText = new Dictionary<int, string>(39);
        List<char> CharAlphavite = new List<char>();

        List<string> Check = new List<string>();
        List<string> Shifts = new List<string>();
        List<string> crypt = new List<string>();
        List<int> Step = new List<int>();
        List<int> U = new List<int>();



        List<int> Value = new List<int>();
        List<int> ValueNew = new List<int>();
        List<int> FibonaccyShift = new List<int>();


        int IndexBefore;
        int IndexAfter;

        int[] Range = new int[50];

     
        string Crypt;
        public string OriginText;
        public string KeyText;

        char[] Letter;
        char[] Gamma;
        char[] Result;

        int[] A = new int[5];
        int Diagonal;
        int Shifted;

        bool Rus;
        bool Eng;

        public Crypto(string original, string Key, int Diagonal, bool Rus, bool Eng)
        {
            this.OriginText = original;
            this.KeyText = Key;
            this.Diagonal = Diagonal;
            this.Rus = Rus;
            this.Eng = Eng;
           
        
            Initialization(Rus, Eng);
            //Code(One, Two, Three, OriginText, KeyText);
            //FibonaccyGamm(Four, Five, Six);
            
            
        }

        public void Initialization(bool Rus, bool Eng)
        {
            if (Eng == true)
            {
                CharAlphavite.Add('a');
                CharAlphavite.Add('b');
                CharAlphavite.Add('c');
                CharAlphavite.Add('d');
                CharAlphavite.Add('e');
                CharAlphavite.Add('f');
                CharAlphavite.Add('g');
                CharAlphavite.Add('h');
                CharAlphavite.Add('i');
                CharAlphavite.Add('j');
                CharAlphavite.Add('k');
                CharAlphavite.Add('l');
                CharAlphavite.Add('m');
                CharAlphavite.Add('n');
                CharAlphavite.Add('o');
                CharAlphavite.Add('p');
                CharAlphavite.Add('q');
                CharAlphavite.Add('r');
                CharAlphavite.Add('s');
                CharAlphavite.Add('t');
                CharAlphavite.Add('u');
                CharAlphavite.Add('v');
                CharAlphavite.Add('w');
                CharAlphavite.Add('x');
                CharAlphavite.Add('y');
                CharAlphavite.Add('z');
                CharAlphavite.Add('.');
                CharAlphavite.Add(',');
                CharAlphavite.Add('!');
                CharAlphavite.Add(':');
                CharAlphavite.Add(';');
                CharAlphavite.Add('-');

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



                CodeText.Add(0, "a");
                CodeText.Add(1, "b");
                CodeText.Add(2, "c");
                CodeText.Add(3, "d");
                CodeText.Add(4, "e");
                CodeText.Add(5, "f");
                CodeText.Add(6, "g");
                CodeText.Add(7, "h");
                CodeText.Add(8, "i");
                CodeText.Add(9, "j");
                CodeText.Add(10, "k");
                CodeText.Add(11, "l");
                CodeText.Add(12, "m");
                CodeText.Add(13, "n");
                CodeText.Add(14, "o");
                CodeText.Add(15, "p");
                CodeText.Add(16, "q");
                CodeText.Add(17, "r");
                CodeText.Add(18, "s");
                CodeText.Add(19, "t");
                CodeText.Add(20, "u");
                CodeText.Add(21, "v");
                CodeText.Add(22, "w");
                CodeText.Add(23, "x");
                CodeText.Add(24, "y");
                CodeText.Add(25, "z");
                CodeText.Add(26, ".");
                CodeText.Add(27, ",");
                CodeText.Add(28, "!");
                CodeText.Add(29, "?");
                CodeText.Add(30, ":");
                CodeText.Add(31, ";");
                CodeText.Add(32, "-");

            }

            if (Rus == true)
            {
                CharAlphavite.Add('а');
                CharAlphavite.Add('б');
                CharAlphavite.Add('в');
                CharAlphavite.Add('г');
                CharAlphavite.Add('д');
                CharAlphavite.Add('е');
                CharAlphavite.Add('ё');
                CharAlphavite.Add('ж');
                CharAlphavite.Add('з');
                CharAlphavite.Add('и');
                CharAlphavite.Add('к');
                CharAlphavite.Add('л');
                CharAlphavite.Add('м');
                CharAlphavite.Add('н');
                CharAlphavite.Add('о');
                CharAlphavite.Add('п');
                CharAlphavite.Add('р');
                CharAlphavite.Add('с');
                CharAlphavite.Add('т');
                CharAlphavite.Add('у');
                CharAlphavite.Add('ф');
                CharAlphavite.Add('х');
                CharAlphavite.Add('ц');
                CharAlphavite.Add('ч');
                CharAlphavite.Add('ш');
                CharAlphavite.Add('щ');
                CharAlphavite.Add('ъ');
                CharAlphavite.Add('ы');
                CharAlphavite.Add('ь');
                CharAlphavite.Add('э');
                CharAlphavite.Add('ю');
                CharAlphavite.Add('я');
                CharAlphavite.Add('.');
                CharAlphavite.Add(',');
                CharAlphavite.Add('!');
                CharAlphavite.Add(':');
                CharAlphavite.Add(';');
                CharAlphavite.Add('-');
                CharAlphavite.Add(' ');

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



                CodeText.Add(0, "а");
                CodeText.Add(1, "б");
                CodeText.Add(2, "в");
                CodeText.Add(3, "г");
                CodeText.Add(4, "д");
                CodeText.Add(5, "е");
                CodeText.Add(6, "ё");
                CodeText.Add(7, "ж");
                CodeText.Add(8, "з");
                CodeText.Add(9, "и");
                CodeText.Add(10, "й");
                CodeText.Add(11, "к");
                CodeText.Add(12, "л");
                CodeText.Add(13, "м");
                CodeText.Add(14, "н");
                CodeText.Add(15, "о");
                CodeText.Add(16, "п");
                CodeText.Add(17, "р");
                CodeText.Add(18, "с");
                CodeText.Add(19, "т");
                CodeText.Add(20, "у");
                CodeText.Add(21, "ф");
                CodeText.Add(22, "х");
                CodeText.Add(23, "ц");
                CodeText.Add(24, "ч");
                CodeText.Add(25, "ш");
                CodeText.Add(26, "щ");
                CodeText.Add(27, "ъ");
                CodeText.Add(28, "ы");
                CodeText.Add(29, "ь");
                CodeText.Add(30, "э");
                CodeText.Add(31, "ю");
                CodeText.Add(32, "я");
                CodeText.Add(33, ".");
                CodeText.Add(34, ",");
                CodeText.Add(35, "!");
                CodeText.Add(36, "?");
                CodeText.Add(37, ":");
                CodeText.Add(38, ";");
                CodeText.Add(39, "-");
            }
           

        }

        public string Code(CryptoAlg aAlg, int Shift)
        {
            Letter = OriginText.ToCharArray();

            if (aAlg == CryptoAlg.Cesar)
            {

                StringBuilder Cesar = new StringBuilder();
                for (int i = 0; i < Letter.Length; i++)
                {
                    IndexBefore = CharAlphavite.IndexOf(Letter[i]);
                    if (IndexBefore + Shift < CharAlphavite.Count)
                        IndexAfter = IndexBefore + Shift;
                    else
                        IndexAfter = Shift;

                    Cesar.Append(CharAlphavite[IndexAfter]);
                    //Cesar.Replace(CharAlphavite[IndexBefore], CharAlphavite[IndexAfter], i, 1);
                }
                Crypt = Cesar.ToString();
                
            }



            if (aAlg == CryptoAlg.Viganer)
            {

                Gamma = KeyText.ToCharArray();
                Letter = OriginText.ToCharArray();

                StringBuilder Viganer = new StringBuilder();
                for (int i = 0; i < Letter.Length; i++)
                {
                    IndexBefore = CharAlphavite.IndexOf(Letter[i]);
                    Shift = CharAlphavite.IndexOf(Gamma[i]);
                    if (IndexBefore + Shift < CharAlphavite.Count)
                        IndexAfter = IndexBefore + Shift;
                    else
                        IndexAfter = Shift;


                    Viganer.Append(CharAlphavite[IndexAfter]);
                    //Viganer.Replace(CharAlphavite[IndexBefore], CharAlphavite[IndexAfter], i, 1);
                }
                Crypt = Viganer.ToString();

            }
            return Crypt;
        }

            
            

        

        public string FibonaccyGamm(bool FibEnum, bool FibRec)
        {
            Letter = OriginText.ToCharArray();

            if (FibEnum)
            {

                U.Add(0);
                U.Add(1);

                for (int i = 2; i < Letter.Length; i++)
                {
                    U.Add(U[i - 1] + U[i - 2]);
                   
                }
                FibonaccyShift = U;
            }

            if (FibRec)
            {
                U.Add(0);
                U.Add(1);
                for (int i = 2; i < Letter.Length; i++)
                {
                    if (i < 5)
                    {
                        U.Add(A[0] * U[i - 1] + A[1] * U[i - 2]);

                    }
                    else
                    {

                        U.Add(A[0] * U[i - 1] + A[1] * U[i - 2] + A[2] * U[i - 3] + A[3] * U[i - 4] + A[4] * U[i - 5]);

                    }
                    FibonaccyShift.Add(U[i]);
                }
            }


            for (int i = 0; i < FibonaccyShift.Count; i++)
            {
                do
                {

                    FibonaccyShift[i] %= alphavite.Count;
                }
                while (FibonaccyShift[i] > alphavite.Count);
                Step.Add(Math.Abs(FibonaccyShift[i]));
            }

            StringBuilder Fibonaccy = new StringBuilder();
            for (int i = 0; i < Letter.Length; i++)
            {
                IndexBefore = CharAlphavite.IndexOf(Letter[i]);
                
                if (IndexBefore + Step[i] < CharAlphavite.Count)
                    IndexAfter = IndexBefore + Step[i];
                else
                    IndexAfter = Step[i];

                Fibonaccy.Append(CharAlphavite[IndexAfter]);
                //Fibonaccy.Replace(CharAlphavite[IndexBefore], CharAlphavite[IndexAfter], i, 1);
            }
            Crypt = Fibonaccy.ToString();
            return Crypt;
        }

        public string FibonaccyKey()
        {
            for (int i = 0; i < FibonaccyShift.Count; i++)
            {
                KeyText += FibonaccyShift[i].ToString();
            }

                return KeyText;
        }


        public string ExchangeTables()
        {
            char[,] Matrix = null;

            Letter = OriginText.ToCharArray();
            Gamma = KeyText.ToCharArray();

            for (int i = 0; i < Gamma.Length; i++)
            {
                Check.Add(Gamma[i].ToString());    
            }

            if (Diagonal > Gamma.Length)
            {
                for (int i = Gamma.Length; i < Diagonal; i++)
                {
                    Diagonal = Gamma.Length;
                }
            }
            else if (Diagonal < Gamma.Length)
            {
                for (int i = Diagonal; i < Gamma.Length; i++)
                {
                    Gamma[i] = '0';
                }
            }


            int lI = 0;
            int cI = 0;
            for (int i = 0; i < (Letter.Length / Math.Pow(Diagonal, 2)) + 1; i++)
            {
                Matrix = new char[Diagonal, Diagonal];
               
                for (int j = 0; j < Diagonal; j++)
                {
                    for (int k = 0; k < Diagonal && lI < Letter.Length; k++)
                    {
                        Matrix[k, j] = Letter[lI++];
                    }
                }

                for (int k = 0; k < Diagonal; k++)
                {
                    Range[k] = alphavite[Check[k]];
                    for (int j = 0; j < Diagonal; j++)
                    {
                        char tmp = Matrix[k, j];
                        Matrix[k, j] = Matrix[Range[k], j];
                        Matrix[Range[k], j] = tmp;
                    }
                }

                for (int n = 0; n < Diagonal; n++)
                {
                    for (int k = 0; k < Diagonal && Matrix[n, k] != '\0'; k++)
                    {
                        Crypt += Matrix[n, k].ToString();
                    }
                }
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
