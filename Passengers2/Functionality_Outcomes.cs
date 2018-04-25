﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.IO;

namespace Passengers2
{
    /// <summary>
    /// Класс для работы с расходами. Методы для расходов, и вся куйня
    /// </summary>
    public partial class Functionality
    {


        public bool AddOutcome(int cost = 0, string extra = "", Category category = Category.Auto)
        {
            try
            {
                Outcome outcome = new Outcome();
                outcome.Cost = cost;
                outcome.Extra = extra;
                outcome.Id = GetNewId(Id.outcome);
                if (WriteOutcome(outcome))
                {
                    return true;

                }
                // по идее можно выбрасить новое исключение
                //new Exception("Не удалось записать расход");
                return false;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }

        private bool WriteOutcome(Outcome outcome)
        {
            try
            {
                //загружаем элемент
                xDocOutcomes.Load(outcomesWay);
                //
                XmlElement xRoot = xDocOutcomes.DocumentElement;
                //создание записи
                XmlElement newOutcome = xDocOutcomes.CreateElement("Outcome");
                //Атрибуты
                XmlAttribute idAttr = xDocOutcomes.CreateAttribute("ID");
                XmlAttribute categoryAttr = xDocOutcomes.CreateAttribute("Category");
                //наполнение инфой
                XmlElement costElement = xDocOutcomes.CreateElement("Cost");
                XmlElement extraElement = xDocOutcomes.CreateElement("Extra");
                XmlElement dateElement = xDocOutcomes.CreateElement("Date");
                //Значения
                XmlText idText = xDocOutcomes.CreateTextNode(outcome.Id.ToString());

                XmlText costText = xDocOutcomes.CreateTextNode(outcome.Cost.ToString());
                XmlText dateText = xDocOutcomes.CreateTextNode(outcome.Date.ToString());
                XmlText extraText = xDocOutcomes.CreateTextNode(outcome.Extra);
                XmlText categoryText = xDocOutcomes.CreateTextNode(outcome.Category.ToString());

                idAttr.AppendChild(idText);
                categoryAttr.AppendChild(categoryText);
                costElement.AppendChild(costText);
                extraElement.AppendChild(extraText);
                dateElement.AppendChild(dateText);


                newOutcome.Attributes.Append(idAttr);
                newOutcome.Attributes.Append(categoryAttr);
                newOutcome.AppendChild(costElement);
                newOutcome.AppendChild(dateElement);
                newOutcome.AppendChild(extraElement);

                xRoot.AppendChild(newOutcome);
                xDocOutcomes.Save(outcomesWay);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
            
        }

        enum Id
        {
            outcome,
            trip
        }
        private int GetNewId(Id kind)
        {
            int _id = 0;

            switch (kind)
            {
                case Id.outcome:
                    if (GetOutcomes().Count != 0)
                    {
                        foreach (Outcome t in GetOutcomes())
                        {
                            if (t.Id >= _id)
                            {
                                _id = ++t.Id;
                            }
                        }
                        return _id;
                    }
                    return _id;
                        
                        
                case Id.trip:
                    if (GetTrips().Count != 0)
                    {
                        foreach (Trip t in GetTrips())
                        {
                            if (t.Id >= _id)
                            {
                                _id = ++t.Id;
                            }
                        }

                        return _id;
                    }
                    return _id;
            }

            return _id;
        }

        public List<Outcome> GetOutcomes()
        {
            List<Outcome> listOutcome = new List<Outcome> { };

            XmlElement xRoot = xDocOutcomes.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Outcome result = new Outcome();

                result.Id = int.Parse(xnode.Attributes.GetNamedItem("ID").Value);
                //TODO: как парсить категорию, которая является перечислением
                //result.Category = Category.(xnode.Attributes.GetNamedItem("Category").Value);

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
                }
                listOutcome.Add(result);
            }

            return listOutcome;
        }
        private Outcome ReadOutcome(int id)
        {
            XmlElement xRoot = xDocOutcomes.DocumentElement;
            Outcome result = new Outcome();
            foreach (XmlNode xnode in xRoot)
            {

                if (xnode.Attributes.GetNamedItem("ID").Value.Equals(id.ToString()))
                {
                    result.Id = id;
                    //TODO: опять с категорией непонятка
                    //result.Category = Category.
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
                    }
                    return result;
                }
            }
            throw new Exception("Нет такой записи");
        }

    }
}
