using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emodji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> texts = new List<string>();
        public List<string> emodjis = new List<string>();
        public List<string> emodjisst = new List<string>();
        public List<string> rez = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            emodjisst = new List<string>(File.ReadAllLines("emst.txt"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            //richTextBox1.AppendText(openFileDialog1.FileName+Environment.NewLine);
            texts = new List<string>(File.ReadAllLines(openFileDialog1.FileName));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            //richTextBox1.AppendText(openFileDialog1.FileName+Environment.NewLine);
            emodjis = new List<string>(File.ReadAllLines(openFileDialog1.FileName));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string str = "";
            foreach (string text in texts)
            {
                str = text + " " + emodjis[rnd.Next(emodjis.Count)] + emodjisst[0];
                rez.Add(str);
                richTextBox1.AppendText(str+Environment.NewLine);

            }
            File.WriteAllLines("result.txt",rez);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
                 richTextBox1.ScrollToCaret();
        }
    }
}
