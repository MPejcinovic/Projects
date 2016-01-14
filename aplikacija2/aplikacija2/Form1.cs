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
using System.Security.Cryptography;

namespace aplikacija2
{
    public partial class Form1 : Form
    {
        int num;
        public Form1()
        {
            InitializeComponent();
            //string content = File.ReadAllText(@"C:\\Users\\Matea\\Desktop\\bezze.txt");
            //richTextBox1.Text = content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(textBox2.Text);
            //Stream myStream;
            Generator.generiraj(num);
            Zapis.hashing();
            Stream zapis;
            OpenFileDialog of = new OpenFileDialog();
            Stream my;
            OpenFileDialog d = new OpenFileDialog();
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((zapis = of.OpenFile()) != null)
                {
                    string name = of.FileName;
                    string fileText = File.ReadAllText(name);
                    richTextBox2.Text = fileText;
                }
            }

            
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((my = d.OpenFile()) != null)
                {
                    string name = d.FileName;
                    string fileText = File.ReadAllText(name);
                    richTextBox1.Text = fileText;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //timer1.Start();
            StreamWriter tw = new StreamWriter("C:\\Users\\Matea\\Desktop\\file.txt");
            Stream myStream;
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                tw.WriteLine(richTextBox2.Lines[i]);
            }
            tw.Flush();
            tw.Close();
            Zapis.hashing();

           

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = ofd.OpenFile()) != null)
                {
                    string name = ofd.FileName;
                    string fileText = File.ReadAllText(name);
                    richTextBox1.Text = fileText;
                }
            }

           
        }

        /*
        private void textBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Title = "Save as text file";
            if (sfd.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(@"C:\\Users\\Matea\\Desktop\\file.txt",textBox1.Text);
            Zapis.hashing();
        }
        */
        

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 sistema = new Form1();
            sistema.ShowDialog();
            this.Close();
        }

        
    }
}
