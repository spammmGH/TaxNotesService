using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers2
{

    class ConsoleView
    {

        public void Run()
        {
            //справка
            ShowHelp();

            //взаимодействие
            Functionality Func = new Functionality();
            string input;

            //бесконечная обработка пользовательсокго ввода
            while (true)
            {
                input = Console.ReadLine();

                if (input.Equals("exit"))
                {
                    break;
                }
                if (input.Equals("addTrip"))
                {
                    Func.AddNewTrip();
                }

                if (input.Equals("summ"))
                {
                    //Console.WriteLine(Func.GetSumm());
                }
                if (input.Equals("help"))
                {
                    ShowHelp();
                }

                if (input.Equals("getTrip"))
                {
                    Console.WriteLine("enter id of the trip: ");
                    int _id;
                        int.TryParse(Console.ReadLine(), out _id);
                    Console.WriteLine(Func.GetTrip(_id).ToString());
                }
                if (input.Equals("getTrips"))
                {

                    foreach (Trip t in Func.GetTrips())
                    {
                        Console.WriteLine(t.ToString());
                    }
                }

                if (input.Equals("getTripsDay"))
                {
                    DateTime date = DateTime.Now.Date;
                    foreach (Trip t in Func.GetTrips())
                    {
                        Console.WriteLine(t.ToString());
                    }
                }
                if (input.Equals("addOutcome"))
                {
                    Func.AddOutcome(cost: 500);
                }
                if (input.Equals("delete"))
                {
                    if (Func.DeleteTrip(1))
                    {
                        Console.WriteLine("deleted");
                    }
                    else
                    {
                        Console.WriteLine("don't exist");
                    }
                }
                if (input.Equals("1"))
                {
                    Outcome outc = new Outcome();
                    Console.WriteLine(outc.Category.ToString());
                }

            }
        }
        private void ShowHelp()
        {
            Console.WriteLine("Commands: \n " +
               " exit \n" +
               " addTrip \n" +
               " show \n" +
               " getTrip \n" +
               " getTrips \n" +
               " delete \n" +
               " getTripsDay \n" +
               " addOutcome \n" +
               "summ \n");
        }
    }
}

