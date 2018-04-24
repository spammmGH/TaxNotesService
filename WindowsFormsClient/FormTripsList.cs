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
    public partial class FormTripsList : Form
    {
        public FormTripsList()
        {
            InitializeComponent();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {




        }

        public void MyMethod(Functionality func)
        {
            ListView lv = listViewTrips;
            lv.View = View.Details;

            int summary = 0;
            int count = 0;
            foreach (Trip t in func.GetTrips())
            {
                ListViewItem lvi = new ListViewItem(t.Date.ToString());
                lvi.SubItems.Add(t.Cost.ToString());
                lvi.SubItems.Add(t.AddressFrom);
                lvi.SubItems.Add(t.AddressTo);
                lvi.SubItems.Add(t.Extra);

                lv.Items.Add(lvi);

                summary += t.Cost;
                count++;

            }
            ListViewItem lastItem = new ListViewItem("Всего: " + count);
            lastItem.SubItems.Add("" + summary);
            lv.Items.Add(lastItem);



        }
    }
}
