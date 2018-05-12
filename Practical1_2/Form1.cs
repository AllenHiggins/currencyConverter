using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Allen Higgins C00197373

namespace Practical1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //define a global var
        private static double amount = 0.0;
        
        private void ErrorMsg()
        {
            //method for any errors 
            MessageBox.Show("Please enter a value for all fields!", "Invalied Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the same value for comboBox2 == comboBox1
            if (comboBox2.SelectedIndex == comboBox1.SelectedIndex)
            {
                //set comboBox2 to index zero - empty string
                comboBox2.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if comboBox1's value is the same as comboBox2
            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                //then set comboBox1 index to zero - empty string
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if textbox value is null or any comboBox values are at index zero - empty string
            if (textBox1.Text == "" || comboBox2.SelectedIndex == 0 || comboBox1.SelectedIndex == 0)
            {
                //call the error message method
                ErrorMsg();
            }
            else 
            {
                //otherwise try store the value as a duoble
                try
                {
                    amount = double.Parse(textBox1.Text);
                }
                catch(Exception)
                {
                    //else the value was not a number, reset the textBox and call the error msg method
                    textBox1.Text = "";
                    ErrorMsg();
                }

                //store the string value of each selection into one string
                string convert = comboBox1.Text + " " + comboBox2.Text;
                //use this string to decide which case is to be carried out
                switch (convert)
                {
                    case "Euro Dollar":
                        amount = amount * 1.11624;
                    break;
                    case "Euro Pound":
                        amount = amount / 0.85355;
                    break;
                    case "Dollar Pound":
                        amount = amount / 0.76439;
                    break;
                    case "Dollar Euro":
                        amount = amount / 0.89589;
                    break;
                    case "Pound Dollar":
                    amount = amount * 1.30775;
                    break;
                    case "Pound Euro":
                        amount = amount * 1.17157;
                    break;
                }
                //set the textBox to the result of the choosen case rounded to 2 deciemal places
                textBox1.Text = Math.Round(amount,2).ToString();
                //change the value of the label to "returns"
                label1.Text = "returns";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reset all fields
            textBox1.Text = "";
            label1.Text = "Amount";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            amount = 0.0;
        }    
    }
}
