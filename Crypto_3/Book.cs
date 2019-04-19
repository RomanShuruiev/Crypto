using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto_3
{
    class Book
    {

        public string Origin;
        public string Key;
        public string Crypt;
        public string CryptInter;
        public string LatticeCourse;
        bool Rus, Eng;
        char[] InterGamma;
        char[] InterLetter;
      
        string[] CryptWSpace;
        
        List<int> NumberLetter = new List<int>();
        List<char> CryptSpace = new List<char>();
        int[] NumberGamma;
        char[] Copy;

        public Book(string original, string key)
        {

            this.Origin = original;
            this.Key = key;
            this.LatticeCourse = LatticeCourse;
            
         }

        public string Lattice(string Origin, string Key)
        {
            List<char> Letter = new List<char>();
            List<char> Gamma = new List<char>();
            List<char> Result = new List<char>();

            InterGamma = Key.ToCharArray();
            InterLetter = Origin.ToCharArray();

            for (int i = 0; i < InterLetter.Length; i++)
            {
                Letter.Add(InterLetter[i]);
            }

            for (int i = 0; i < InterGamma.Length; i++)
            {
                Gamma.Add(InterGamma[i]);
            }
            string CopyString = "";
            StringBuilder ResultInter = new StringBuilder();
            Result = Letter;
            Result.ForEach(delegate(Char c) { CopyString += c; }); 
            for (int i = 0; i < Gamma.Count; i++)
            {
                try
                {

                    NumberLetter.Add(Gamma.IndexOf(Letter[i]));

                    CryptInter += (char)Gamma[NumberLetter[i]];
                }

                catch
                {
                    MessageBox.Show("Недостаточная ширина гаммы");
                 
                }

            }
           
            for (int i = 0; i < CryptInter.Length; i++)
			{
                Crypt += CryptInter[i];
                if (i % 5 == 0 && i != 0)
                    Crypt += ' ';
			}
           
            return Crypt;
        }
    }
}
