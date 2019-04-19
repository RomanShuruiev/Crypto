using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Crypto_3
{


    public partial class Form1 : Form
    {
        private string name;
        public int Diagonal;
        bool Rus;
        bool Eng;

        string Result = "";
        string ResultSpace = "";
        string OriginText = "";
        string KeyText = "";
        string Key = "";
        string Origin = "";

        string[] Algorythmes = new string[] {"Cesar", "Viganer", "ExchangeTables", "FibonaccyGamma", "MD"};

        CryptoAlg Alg;
       
        
        public Form1()
        {
            InitializeComponent();
            /*
            comboBox1.DataSource = new BindingSource() { DataSource = Algorythmes };
            comboBox2.DataSource = new BindingSource() { DataSource = Algorythmes };
            comboBox3.DataSource = new BindingSource() { DataSource = Algorythmes };
            comboBox1.SelectedItem = -1;
            comboBox2.SelectedItem = -1;
            comboBox3.SelectedItem = -1;
            */

        }

       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (Russian.Checked)
            {
                Rus = true;
            }
            if (English.Checked)
            {
                Eng = true;
            }

            //CryptoAlg Alg = 0;

          
             Crypto crypting = new Crypto(
                OriginText,
                KeyText, 
                (int)tabDiag.Value, Rus, Eng);

             MDPM MonoDigraph = new MDPM(
                 Origin,
                 Key,
                  Rus, Eng);

             Book book = new Book(
                 Origin,
                 Key);
              

            if (Alg == CryptoAlg.FibonaccyGamma)
            {
                bool FibEnum = cbFibonaccyEnum.Checked;
                bool FibRec = cbFibonaccyRec.Checked;
                Result = crypting.FibonaccyGamm(FibEnum, FibRec);
                ResultSpace = crypting.Spaces();
                tbResult.Text = ResultSpace;
                tbGamma.Text = crypting.FibonaccyKey();

            }

            else if (Alg == CryptoAlg.MD)
            {
                   
                    Result = MonoDigraph.MD();
                    ResultSpace = MonoDigraph.Spaces();
                    tbResult.Text = ResultSpace;
                
             
            }
            else if (Alg == CryptoAlg.Lattice)
            {
                Result = book.Lattice(Origin, Key);
                tbResult.Text = Result;
            }
            else
            {
                int Shift = (int)nmCesarShift.Value;
           
                if (Alg == CryptoAlg.Cesar | Alg == CryptoAlg.Viganer)
                {
                    Result = crypting.Code(Alg, Shift);
                    ResultSpace = crypting.Spaces();
                    tbResult.Text = ResultSpace;
                }

                if (Alg == CryptoAlg.Viganer)
                {
                    
                    Result = crypting.Code(Alg, Shift);
                    ResultSpace = crypting.Spaces();
                    tbResult.Text = ResultSpace;
                }


                else if (Alg == CryptoAlg.ExchangeTables)
                {
                    Result = crypting.ExchangeTables();
                    ResultSpace = crypting.Spaces();
                    tbResult.Text = ResultSpace;
                }

                else return;
            }
            tabControl1.SelectedTab = tabPage11;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            
            List<CryptoAlg> Methods = new List<CryptoAlg>();
            foreach (ComboBox item in flowLayoutPanel1.Controls)
            {
                Methods.Add((CryptoAlg)item.SelectedIndex);
            }
           
            int Shift = (int)nmCesarShift.Value;
            this.Diagonal = (int)tabDiag.Value;
      
            OriginText = tbText.Text;
            KeyText = tbGamma.Text;

            if (Russian.Checked)
                Rus = true;
            if (English.Checked)
                Eng = true;

            foreach (CryptoAlg item in Methods)
            {
                switch (item)
                {
                    case CryptoAlg.Cesar:
                        {
                            Crypto crypting = new Crypto(
                OriginText,
                KeyText,
                Diagonal, Rus, Eng);
                            Alg = CryptoAlg.Cesar;

                            Result = crypting.Code(Alg, Shift);
                            OriginText = Result;
                            break;
                        }
                    case CryptoAlg.Viganer:
                        {
                            CheckLong CheckViganer = new CheckLong(
                            Origin,
                             KeyText);

                            Alg = CryptoAlg.Viganer;
                            Origin = tbText.Text;

                            KeyText = CheckViganer.Check(OriginText, KeyText);
                            Crypto crypting = new Crypto(
                            OriginText,
                            KeyText,
                            Diagonal, Rus, Eng);

                            Result = crypting.Code(Alg, Shift);
                            tbGamma.Text = KeyText;
                            OriginText = Result;
                            break;
                        }

                    case CryptoAlg.ExchangeTables:
                        {
                            Crypto crypting = new Crypto(
                OriginText,
                KeyText,
                Diagonal, Rus, Eng);
                            Alg = CryptoAlg.ExchangeTables;


                            Diagonal = (int)tabDiag.Value;
                            Result = crypting.ExchangeTables();
                            OriginText = Result;
                            break;
                        }
                    case CryptoAlg.FibonaccyGamma:
                        {
                            Crypto crypting = new Crypto(
                OriginText,
                KeyText,
                Diagonal, Rus, Eng);
                            int[] A = new int[5];

                            A[0] = (int)numericUpDown2.Value;
                            A[1] = (int)numericUpDown3.Value;
                            A[2] = (int)numericUpDown4.Value;
                            A[3] = (int)numericUpDown5.Value;
                            A[4] = (int)numericUpDown6.Value;
                            Alg = CryptoAlg.FibonaccyGamma;

                            bool FibEnum = cbFibonaccyEnum.Checked;
                            bool FibRec = cbFibonaccyRec.Checked;
                            Result = crypting.FibonaccyGamm(FibEnum, FibRec);

                            OriginText = Result;
                            break;
                        }
                    case CryptoAlg.MD:
                        {
                            MDPM MonoDigraph = new MDPM(OriginText, KeyText, Rus, Eng);

                            Alg = CryptoAlg.MD;
                            Result = MonoDigraph.MD();
                            OriginText = Result;
                            break;
                        }

                    case CryptoAlg.Lattice:
                        {
                            Book book = new Book(
                OriginText,
                KeyText);
                            Alg = CryptoAlg.Lattice;

                            Result = book.Lattice(OriginText, Key);
                            OriginText = Result;
                            break;
                        }
                    default:
                        break;
                }
                tbResult.Text = Result;
            }
        }
        
        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                tbText.Clear();
                tbText.Text = File.ReadAllText(name);
              
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, tbResult.Text);
               
            }
        }

        private void openKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog2.FileName;
                tbGamma.Clear();
                tbGamma.Text = File.ReadAllText(name);
       
            }
        }

        private void viganerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alg = CryptoAlg.Cesar;
            OriginText = tbText.Text;
            KeyText = tbGamma.Text;
        }

        private void viganerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckLong CheckViganer = new CheckLong(
                Origin,
                Key);

            Alg = CryptoAlg.Viganer;
            Origin = tbText.Text;
            OriginText = tbText.Text;
            Key = tbGamma.Text;
            KeyText = CheckViganer.Check(Origin, Key);
            tbGamma.Text = KeyText;
        }

        private void exchangeTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alg = CryptoAlg.ExchangeTables;
            OriginText = tbText.Text;
            KeyText = tbGamma.Text;
            Diagonal = (int)tabDiag.Value;
        }

        private void fibonaccyGammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] A = new int[5];
       
            A[0] = (int)numericUpDown2.Value;
            A[1] = (int)numericUpDown3.Value;
            A[2] = (int)numericUpDown4.Value;
            A[3] = (int)numericUpDown5.Value;
            A[4] = (int)numericUpDown6.Value;
            Alg = CryptoAlg.FibonaccyGamma;
            OriginText = tbText.Text;
        }

        private void mDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alg = CryptoAlg.MD;
            Origin = tbText.Text;
            Key = tbGamma.Text;
        }

        private void latticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alg = CryptoAlg.Lattice;
            Origin = tbText.Text;
            Key = tbGamma.Text;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb.Size = new Size(flowLayoutPanel1.Width - 6, cb.Height);
            cb.DataSource = new BindingSource() { DataSource = Algorythmes };
            flowLayoutPanel1.Controls.Add(cb);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int count = flowLayoutPanel1.Controls.Count;
            if(count > 0)
            flowLayoutPanel1.Controls.RemoveAt(count - 1);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void tabDiag_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
