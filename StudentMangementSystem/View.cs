using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StudentMangementSystem
{
    public partial class View : Form

    {
        int count;
        int position = 0;
        string fileContent;
        string[] strArray;
        public View()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void View_Load(object sender, EventArgs e)
        {
             count = File.ReadAllLines(@"C:/Users/Admin/Desktop/MyData.txt").Count();
            //  fistRecord=File.ReadLines(@"C:/Users/Admin/Desktop/MyData.txt").Count();
           // ShowData(position);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            position++;
            if (position <=count)
            {
                ShowData(position);
            }
            else 
            {
                btnNext.Enabled = false;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            position--;
            if (position>=0)
            {
               
                ShowData(position);
            }
            else
            {
                btnPrevious.Enabled = false;
            }
        }
        public int ShowData(int position)
        {
            using (var streamReader = File.OpenText(@"C:/Users/Admin/Desktop/MyData.txt"))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] stringSeparators = new string[] { "))", "+", "|", "*" };
                    strArray = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    
                    if (position == Convert.ToInt32(strArray[0]))
                    {
                        label1.Text = position.ToString() + "/" + count.ToString();
                        txtUsername.Text = strArray[1];
                        txtPlace.Text = strArray[2];
                        txtPhoneNumber.Text = strArray[3];
                        txtEmail.Text = strArray[4];
                    }
                }
            }
           
           return 1;


        }
    }
}
