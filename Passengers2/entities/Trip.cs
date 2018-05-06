using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Passengers2
{
    public class Trip : Note
    {

        private string addressTo = "";
        private string addressFrom = "";
        

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

        public Trip()
        {
        }

        public override string GetInfo()
        {
            return this.date.ToString() + " поездка стоимостью " + this.cost.ToString() + " из " + this.AddressFrom + " в " + this.addressTo + "\n";
        }
    }
}
