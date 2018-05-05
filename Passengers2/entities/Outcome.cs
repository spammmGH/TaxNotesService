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


        private int id = 0;
        private DateTime date = DateTime.Now;
        private string extra = "";
        private Category category = Category.Auto;
        private int cost = 0;

        public string Extra
        {
            get
            {
                return extra;
            }
            set { extra = value; }
        }

        public Category Category
        {
            get
            {
                return category;
            }
            set { category = value; }
        }
        //public DateTime Date
        //{
        //    get
        //    {
        //        return date;
        //    }
        //    set { date = value; }
        //}
        public int Cost
        {
            get
            {
                return cost;
            }
            set { cost = value; }
        }
        //public int Id
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    set { id = value; }
        //}
        public Outcome()
        {

        }

        public override string GetInfo()
        {
            return date.ToString() + " " + category.ToString() + " на сумму " + cost + " " + extra;
        }
    }
}
