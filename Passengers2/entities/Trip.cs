using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Passengers2
{
    public class Trip
    {
        private int id;
        private int cost = 100;
        private DateTime date = DateTime.Now;
        private string extra = "";
        private string addressTo = "";
        private string addressFrom = "";
        


        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value > 0)
                    cost = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }

        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string AddressTo
        {
            get
            {
                return addressTo;
            }
            set
            {
                addressTo = value;
            }
        }
        public string AddressFrom
        {
            get
            {
                return addressFrom;
            }
            set
            {
                addressFrom = value;
            }
        }
        public string Extra
        {
            get { return extra; }
            set { extra = value; }
        }


        //Конструкторы

       
            //Поездка с пустыми значениями
        public Trip()
        {
            ////TODO: это неправильное решение. Надо чет по другому айди хранить
            //var settings = ConfigurationManager.AppSettings;
            //int _id = int.Parse(settings["Id"]);

            //Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //currentConfig.AppSettings.Settings["Id"].Value = (++id).ToString();
            //currentConfig.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");


            //id = ++id;
            //settings["id"] = id.ToString();

        }

        public override string ToString()
        {
            return this.date.ToString() + " поездка стоимостью " + this.cost.ToString() + " из " + this.AddressFrom + " в " + this.addressTo + "\n";
        }
    }
}
