using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers2
{
    public abstract class Note
    {
        private int id;
        private DateTime date;

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

public abstract string GetInfo();
    }
}
