using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikacija
{
    public partial class Form1 : Form
    {
        string a;
        double[] polje = new double[2];
        int snaga;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         //   textBox1.Text = a;
          //  textBox1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Text = polje[0].ToString();
            textBox2.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //textBox3.Text = polje[1].ToString();
            textBox3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            snaga = Rjecnik.Provjera(textBox1.Text);
            if (snaga == 0)
            {
                polje = entropija.Ulaz(textBox1.Text);
                textBox2.Text = polje[0].ToString();
                textBox3.Text = polje[1].ToString();
                if (polje[1] < 100)
                {
                    richTextBox1.Text = "Vaša zaporka je slaba; probajte povećati broj znakova kombinirajući velika i mala slova s brojevima te specijalnim znakovima.";
                }
                else 
                {
                    if ((polje[1] > 100) && (polje[1] < 200)) 
                    {
                        richTextBox1.Text = "Vaša zaporka je srednje jačine. Za jaču zaporku preporučuje se koristiti kombinaciju velikih i malih slova, brojeva i specijslnih znakova.";
                    }
                    else 
                    {
                        richTextBox1.Text = "Jačina vaše zaporke je zadovoljavajuća.";
                    }
                }
                
            }
            else 
            {
                if (snaga == 1)
                {
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    richTextBox1.Text = "Zaporka koju ste unijeli je jedna od najčešće korištenih. Radi sigurnosti vaših podataka, najbolje je promijeniti je.";
                    groupBox1.Text = '0' + "%";

                }
                else 
                {
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    richTextBox1.Text = "Vašu zaporku je moguće probiti napadom rječnikom. Radi sigurnosti vaših podataka, najbolje je promijeniti je.";
                    groupBox1.Text = '0' + "%";
                }
            }

            int counter = 0;
            int rowmax = 400;
            int colmax = 400;

            decimal percentage;

            for (int i = 0; i < polje[1]; i++)
            {
                for (int y = 0; y < colmax; y++)
                {
                    counter++;
                }


                percentage = (decimal)counter / (rowmax * colmax);
                groupBox1.Text = ((int)(percentage * 100)).ToString() + "%";
                groupBox1.Refresh();

                label7.Width = Convert.ToInt32(percentage * (groupBox1.Width - 10));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Show();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 sistema = new Form1();
            sistema.ShowDialog();
            this.Close();

        }
    }
}
