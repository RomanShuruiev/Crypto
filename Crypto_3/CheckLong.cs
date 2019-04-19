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
    class CheckLong
    {
        public string Origin;
        public string Parol;
        public string Key;
        List<char> KeyNew = new List<char>();
        char[] Letter;
        char[] Gamma;
        string PlusGamma;

        public CheckLong(string original, string key)
        {

            this.Origin = original;
            this.Key = key;
            
        
        }

        public string Check(string Origin, string Key) 
        {
            Letter = Origin.ToCharArray();
            Gamma = Key.ToCharArray();

            if (Letter.Length > Gamma.Length)
            {
                if (MessageBox.Show("Недостаточная длина ключа.Сгенерировать ключ?", "Ключ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < Letter.Length; i++)              
                        KeyNew.Add(Key[i % Key.Length]);
                       
                    //KeyNew.CopyTo(Gamma);
                    Parol = new string(KeyNew.ToArray());
                }
                else
                {
                    Parol = Gamma.ToString();
                }
            }

            if (Letter.Length < Gamma.Length)
            {
                for (int i = Letter.Length; i < Gamma.Length; i++)
                {
                    Gamma[i] = '0';
                }
                Parol = Gamma.ToString();
            }

           return Parol;
        }
        
    }





      }



           

        
    

