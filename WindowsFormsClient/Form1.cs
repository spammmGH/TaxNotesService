using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Passengers2;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        Functionality func = new Functionality();

        public Form1()
        {
            InitializeComponent();
            listBoxCost.SelectedItem = "100";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: здесь типо всплывающее окошко, где можно ввести любую сумм поездки. Но оно должно появляться сразу при выборе трех точек, а не при нажатии "добавить"
            if (listBoxCost.SelectedItem.Equals("..."))
            {
                
            }
            int cost = Int32.Parse((String)listBoxCost.SelectedItem);
            string extra = textBoxExtra.Text;
            string addressFrom = textBoxFrom.Text;
            string addressTo= textBoxTo.Text;
            func.AddNewTrip(cost: cost, extra: extra, addressFrom:addressFrom, addressTo:addressTo);


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTripsList form2 = new FormTripsList();
            form2.MyMethod(func);
            form2.Show();
            //Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
