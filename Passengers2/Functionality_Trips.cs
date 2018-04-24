using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace Passengers2
{
    public partial class Functionality : Object
    {

        //private List<Trip> trips = new List<Trip>();

            //чисто настройки
        private NameValueCollection settings;
        private string xmlTrips;
        private string xmlOutcomes;

        private XmlDocument xDocTrips = new XmlDocument();
        private XmlDocument xDocOutcomes = new XmlDocument();


        // файлы записи
        FileStream fileTrips;
        FileStream fileOutcomes;


        public Functionality()
        {

            settings = ConfigurationManager.AppSettings;
            xmlTrips = settings["XmlTrips"];
            xmlOutcomes = settings["XmlOutcomes"];

            try
            {
                fileTrips = new FileStream(xmlTrips, FileMode.Open);
                //test
                fileTrips.Close();

            }
            catch (Exception e)
            {
                fileTrips = new FileStream(xmlTrips, FileMode.Create);
                XmlDocument _doc = new XmlDocument();
                //создание объявления (декларации) документа

                _doc.AppendChild(_doc.CreateXmlDeclaration("1.0", "utf-8", null));
                XmlElement root = _doc.CreateElement("Trips");
                _doc.AppendChild(root);
                _doc.Save(fileTrips);
                //test
                fileTrips.Close();
            }
            try
            {
                fileOutcomes = new FileStream(xmlOutcomes, FileMode.Open);
                //test
                fileOutcomes.Close();

            }
            catch (Exception e)
            {
                fileOutcomes = new FileStream(xmlOutcomes, FileMode.Create);
                XmlDocument _doc = new XmlDocument();
                //создание объявления (декларации) документа

                _doc.AppendChild(_doc.CreateXmlDeclaration("1.0", "utf-8", null));
                XmlElement root = _doc.CreateElement("Outcomes");
                _doc.AppendChild(root);
                _doc.Save(fileOutcomes);
                //test
                fileOutcomes.Close();
            }


            try
            {
                xDocTrips.Load(xmlTrips);

            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }

        }


        public bool AddNewTrip(int cost = 100, string extra = "", string addressTo = "", string addressFrom = "")
        {
            try
            {
                Trip myTrip = new Trip
                {
                    Extra = extra,
                    AddressFrom = addressFrom,
                    AddressTo = addressTo,
                    Cost = cost
                };
                //trips.Add(myTrip);
                WriteTrip(myTrip);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public List<Trip> GetTrips()
        {
            List<Trip> listTrip = new List<Trip> { };

            XmlElement xRoot = xDocTrips.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Trip result = new Trip();

                result.Id = int.Parse(xnode.Attributes.GetNamedItem("ID").Value);
                foreach (XmlNode childNode in xnode.ChildNodes)
                {
                    if (childNode.Name == "Cost")
                    {
                        result.Cost = int.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "Date")
                    {
                        DateTime date;
                        //result.Date = DateTime.TryParse(childNode.InnerText, out date);
                        DateTime.TryParse(childNode.InnerText, out date);
                        result.Date = date;
                    }
                    if (childNode.Name == "Extra")
                    {
                        result.Extra = childNode.InnerText;
                    }

                    if (childNode.Name == "AdressTo")
                    {
                        result.AddressTo = childNode.InnerText;
                    }
                    if (childNode.Name == "AdressFrom")
                    {
                        result.AddressFrom = childNode.InnerText;
                    }

                }
                listTrip.Add(result);
            }

            return listTrip;
        }

        public List<Trip> GetTrips(DateTime date)
        {
            List<Trip> listTrip = new List<Trip> { };

            XmlElement xRoot = xDocTrips.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {

                foreach (XmlNode endNode in xnode.ChildNodes)
                {
                    if (endNode.Name == "Date")
                    {
                        DateTime _date;
                        DateTime.TryParse(endNode.InnerText, out _date);
                        //сравниваем дату нода с искомой датой, если удовлетворяет, то  добавляем в коллекцию
                        if (_date.Date == date)
                        {
                            XmlNode _node = endNode.ParentNode;

                            Trip result = new Trip();
                            result.Id = int.Parse(_node.Attributes.GetNamedItem("ID").Value);

                            foreach (XmlNode t in _node.ChildNodes)
                            {
                                if (t.Name == "Date")
                                {
                                    DateTime __date;
                                    DateTime.TryParse(t.InnerText, out __date);
                                    result.Date = __date;
                                }
                                if (t.Name == "Cost")
                                {
                                    result.Cost = int.Parse(t.InnerText);
                                }

                                if (endNode.Name == "Extra")
                                {
                                    result.Extra = t.InnerText;
                                }

                                if (endNode.Name == "AdressTo")
                                {
                                    result.AddressTo = t.InnerText;
                                }
                                if (endNode.Name == "AdressFrom")
                                {
                                    result.AddressFrom = t.InnerText;
                                }

                            }
                            listTrip.Add(result);
                        }



                    }


                }
            }

            return listTrip;
        }




        //public int GetSumm()
        //{
        //    int sum = 0;
        //    foreach(Trip t in trips)
        //    {
        //        sum +=t.Cost;
        //    }
        //    return sum;
        //}

        public Trip GetTrip(int id)
        {
            return ReadTrip(id);
        }

        

        private void WriteTrip(Trip myTrip)
        {
            XmlElement xRoot = xDocTrips.DocumentElement;

            //создание записи
            XmlElement tripElement = xDocTrips.CreateElement("Trip");
            //атрибут ID
            XmlAttribute idAttr = xDocTrips.CreateAttribute("ID");
            //наполнение инфой
            XmlElement costElement = xDocTrips.CreateElement("Cost");
            XmlElement fromElement = xDocTrips.CreateElement("From");
            XmlElement toElement = xDocTrips.CreateElement("To");
            XmlElement extraElement = xDocTrips.CreateElement("Extra");
            XmlElement dateElement = xDocTrips.CreateElement("Date");

            //Значение элементов
            XmlText idText = xDocTrips.CreateTextNode(myTrip.Id.ToString());
            XmlText costText = xDocTrips.CreateTextNode(myTrip.Cost.ToString());
            XmlText fromText = xDocTrips.CreateTextNode(myTrip.AddressFrom);
            XmlText toText = xDocTrips.CreateTextNode(myTrip.AddressTo);
            XmlText extraText = xDocTrips.CreateTextNode(myTrip.Extra);
            XmlText dateText = xDocTrips.CreateTextNode(myTrip.Date.ToString());

            //Заполнение хмл
            //TODO: заполнение айди здесь должно быть
            idAttr.AppendChild(idText);
            costElement.AppendChild(costText);
            fromElement.AppendChild(fromText);
            toElement.AppendChild(toText);
            extraElement.AppendChild(extraText);
            dateElement.AppendChild(dateText);

            //Добавляем созданный элемент в хмл
            tripElement.Attributes.Append(idAttr);
            tripElement.AppendChild(costElement);
            tripElement.AppendChild(fromElement);
            tripElement.AppendChild(toElement);
            tripElement.AppendChild(extraElement);
            tripElement.AppendChild(dateElement);

            xRoot.AppendChild(tripElement);
            xDocTrips.Save(xmlTrips);
        }

        private Trip ReadTrip(int id)
        {
            XmlElement xRoot = xDocTrips.DocumentElement;
            Trip result = new Trip();
            foreach (XmlNode xnode in xRoot)
            {

                if (xnode.Attributes.GetNamedItem("ID").Value.Equals(id.ToString()))
                {
                    result.Id = id;
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.Name == "Cost")
                        {
                            result.Cost = int.Parse(childNode.InnerText);
                        }
                        if (childNode.Name == "Date")
                        {
                            result.Date = DateTime.Parse(childNode.InnerText);
                        }
                        if (childNode.Name == "Extra")
                        {
                            result.Extra = childNode.InnerText;
                        }

                        if (childNode.Name == "AdressTo")
                        {
                            result.AddressTo = childNode.InnerText;
                        }
                        if (childNode.Name == "AdressFrom")
                        {
                            result.AddressFrom = childNode.InnerText;
                        }
                    }
                }
            }
            return result;
        }

        public bool DeleteTrip(int id)
        {
            XmlElement xRoot = xDocTrips.DocumentElement;
            foreach (XmlNode childElement in xRoot)
            {
                if (childElement.Attributes.GetNamedItem("ID").Value.Equals(id.ToString()))
                {
                    xRoot.RemoveChild(childElement);
                    xDocTrips.Save(settings[xmlTrips]);
                    return true;
                }
            }
            return false;

        }


    }
}


