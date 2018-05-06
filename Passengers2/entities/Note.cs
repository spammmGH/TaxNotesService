using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers2
{
    public abstract class Note
    {
        protected int id;
        protected DateTime date;
        protected int cost;
        protected string extra = "";


        public Note()
        {
            date = DateTime.Now;
        }
        public int Cost
        {
            get
            {
                return cost;
            }
            set { cost = value; }
        }

        public string Extra
        {
            get
            {
                return extra;
            }
            set { extra = value; }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set { id = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
public abstract string GetInfo();
    }
}
