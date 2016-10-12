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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // dataGridView1.ColumnCount = 6;
            //dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            //DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            //columnHeaderStyle.BackColor = Color.Beige;
            //columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            //dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
           // dataGridView1.Columns[0].Name = "rank";
            //dataGridView1.Columns[1].Name = "id";
            //dataGridView1.Columns[2].Name = "Title";
            //dataGridView1.Columns[3].Name = "authors";
            //dataGridView1.Columns[4].Name = " Bibliographic information";
            //dataGridView1.Columns[5].Name = " first sentence of abstract";



            
            


        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Firstsentenceofabstract")
            {
                MessageBox.Show("abdcd");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            luceneapplication LA = new luceneapplication();
            
            string indexPath = "C:\\Users\\Tao Wei\\Documents\\Visual Studio 2015\\Projects\\ConsoleApplication2";
            LA.CreateIndex(indexPath);
            // source collection
         
            DateTime start = System.DateTime.Now;
            int t = 1;
            for (t = 1; t < 100; t++)
            {

                string st = null;
                StreamReader sr = new StreamReader(" C:\\Users\\Tao Wei\\Documents\\Visual Studio 2015\\Projects\\ConsoleApplication2\\collection(2)\\crandocs\\" + t.ToString() + ".txt");
                while (sr.Peek() >= 0)
                {
                    st += (char)sr.Read();
                }
                LA.IndexText(st);
            }
            // Index code

            System.Console.WriteLine("Adding Documents to Index");


            System.Console.WriteLine("All documents added.");
            LA.CleanUpIndexer();

            // Searching Code
            LA.CreateSearcher();
            LA.CreateParser();
            string a = textBox1.Text;
            LA.SearchText(a);
            // label4.Text = LA.SearchText(a);  
            dataGridView1.DataSource = LA.SearchText(a);
            LA.CleanUpSearcher();
            
            DateTime end = System.DateTime.Now;
            label3.Text = (start-end).ToString();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
           
              
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
