using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            label1.Text = "please enter the source collection directory";
            label1.ForeColor = Color.Red;
            
            label2.Text = "please enter the index directory";
            label2.ForeColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.Red)
            {
                MessageBox.Show("please enter the source collection directory");
            }
            else if (label2.ForeColor == Color.Red)
            {
                MessageBox.Show("please enter the index directory");
            }
            else { 

            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(); label1.Text = folderBrowserDialog1.SelectedPath; label1.ForeColor = Color.Black;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog(); label2.Text = folderBrowserDialog2.SelectedPath; label2.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
