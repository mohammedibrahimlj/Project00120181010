using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication
{
    public partial class Form1 : Form
    {
        List<int> ScoreList;
        bool valcheck = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ScoreList = new List<int>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ScoreList.Count <= 4)
                {
                    if (!string.IsNullOrEmpty(ScoreBox.Text.Trim().ToString()))
                    {
                        ScoreList.Add(int.Parse(ScoreBox.Text.ToString()));
                        ScoreCalculation();
                        ScoreBox.Text = "";
                    }
                }
                else
                {
                    ScoreBox.Text = "";
                    MessageBox.Show("Demo Application cannot able to add more that 4 scores !!!!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK);

            }
        }
        public void ScoreCalculation()
        {
            int scoreTotal=0;
            foreach(int scores in ScoreList)
            {
                scoreTotal = scoreTotal + scores;
            }
            TotalBox.Text = scoreTotal.ToString();
            AverageBox.Text = int.Parse((scoreTotal / ScoreList.Count()).ToString()).ToString();
            CountBox.Text = (ScoreList.Count()).ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
         {
            if(((e.KeyChar<47) || (e.KeyChar > 58)) && (e.KeyChar!=8))
            {
                valcheck = false;
                MessageBox.Show("Enter only numbers", "Error Message", MessageBoxButtons.OK);
            }
        }

        private void ScoreBox_TextChanged(object sender, EventArgs e)
        {
            if(!valcheck)
            {
                valcheck = true;
                ScoreBox.Text = ScoreBox.Text.ToString().Substring(0, ScoreBox.Text.ToString().Length-1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScoreList = new List<int>();
            ScoreBox.Text = "";
            AverageBox.Text = "";
            ScoreBox.Text = "";
            CountBox.Text = "";
            TotalBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg=string.Empty;
            int i = 0;
            ScoreList.Sort();
            foreach (int scores in ScoreList)
            {
                i++;
                if (i ==1)
                {
                    msg =  scores.ToString();
                }
                else
                {
                    msg = msg +"\n" +scores.ToString();
                }
            }
            MessageBox.Show(msg, "Sorted scores", MessageBoxButtons.OK);
        }
    }
}
