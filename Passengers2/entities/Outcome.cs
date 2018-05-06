using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers2
{
    public enum Category
    {
        Auto, Food, Other
    };

    public class Outcome : Note
    {
        private Category category = Category.Auto;

        public Category Category
        {
            get
            {
                return category;
            }
            set { category = value; }
        }

        public Outcome()
        {
        }

        public override string GetInfo()
        {
            return date.ToString() + " " + category.ToString() + " на сумму " + cost + " " + extra;
        }
    }
}
