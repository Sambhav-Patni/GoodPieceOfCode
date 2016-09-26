using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickDiff_SAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            textBox2.Text = openFileDialog2.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            Boolean flag = false;
            try
            {                
                string[] file1, file2;
                file1 = File.ReadAllLines(textBox1.Text);
                file2 = File.ReadAllLines(textBox2.Text);
                string[] file3 = new string[file1.Length];
                foreach (string str in file1)
                {
                    foreach (string str1 in file2)
                    {
                        if (str.Equals(str1))
                        {
                            flag = false;                           
                        }
                    }
                    if (flag != false)
                    {
                        file3[i++] = str;                        
                    }
                    flag = true;
                }
                File.WriteAllLines(Path.GetDirectoryName(textBox1.Text) + "\\SAM_STD_DiffOut.txt", file3);
                MessageBox.Show("Output Generated : " + Path.GetDirectoryName(textBox1.Text) + "\\SAM_STD_DiffOut.txt", "Done");
            }
            catch(Exception)
            {
                MessageBox.Show("Something Went Wrong...\n\n Contact: Sambhav Patni\n At: Sambhav.patni@infogain.com", "Error Occured");
            }
            Process.Start(Path.GetDirectoryName(textBox1.Text) + "\\SAM_STD_DiffOut.txt");
        }
    }
}
