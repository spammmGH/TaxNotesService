using System;
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
                xDocOutcomes.Load(xmlOutcomes);
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
                xDocOutcomes.Save(xmlOutcomes);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
            
        }
    }
}
