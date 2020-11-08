using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Lab2
{   
    interface IAnalizatorXMLStrategy
    {
        List<Flight> Search(Flight flight);
        
    }
    class AnalizatorXmlDOMStrategy : IAnalizatorXMLStrategy
    {
        public List<Flight> Search(Flight flight)
        {
            List<Flight> result = new List<Flight>();
            string adress = @"E:\Навчання\ООП\Lab2\Lab2\XMLFile1.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(adress);
            XmlNode node = doc.DocumentElement;
            foreach (XmlNode nod in node.ChildNodes)
            {
                string Number = "";
                string Company = "";
                string From = "";
                string To = "";
                string Type = "";
                string Depature = "";
                string Arrival = "";

                foreach (XmlAttribute attribute in nod.Attributes)
                {
                    if (attribute.Name.Equals("Number") && (attribute.Value.Equals(flight.Number) || flight.Number.Equals(String.Empty))) 
                    Number = attribute.Value;
                    if (attribute.Name.Equals("Company") && (attribute.Value.Equals(flight.Company) || flight.Company.Equals(String.Empty))) 
                    Company = attribute.Value;
                    if (attribute.Name.Equals("From") && (attribute.Value.Equals(flight.From) || flight.From.Equals(String.Empty))) 
                    From = attribute.Value;
                    if (attribute.Name.Equals("To") && (attribute.Value.Equals(flight.To) || flight.To.Equals(String.Empty))) 
                    To = attribute.Value;
                    if (attribute.Name.Equals("Type") && (attribute.Value.Equals(flight.Type) || flight.Type.Equals(String.Empty))) 
                    Type = attribute.Value;
                    if (attribute.Name.Equals("Depature") && (Program.TimeCheck(attribute.Value,flight.Depature) || flight.Depature.Equals(String.Empty))) 
                    Depature = attribute.Value;
                    if (attribute.Name.Equals("Arrival") && (Program.TimeCheck(attribute.Value,flight.Arrival) || flight.Arrival.Equals(String.Empty))) 
                    Arrival = attribute.Value;
                }
                if ((Number != "") && (Company != "") && (From != "") && (To != "") && (Type != "") && (Depature != "") && (Arrival != ""))
                    result.Add(new Flight(Number, Company, From, To, Type, Depature, Arrival));
            }
            return result;
        }
       
    }
    class AnalizatorXmlSAXStrategy:IAnalizatorXMLStrategy
    {
        public List<Flight> Search(Flight flight)
        {
            List<Flight> result = new List<Flight>();
            string adress = @"E:\Навчання\ООП\Lab2\Lab2\XMLFile1.xml";
            var xmlReader = new XmlTextReader(adress);
            while (xmlReader.Read())
            {
                if (xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        string Number = "";
                        string Company = "";
                        string From = "";
                        string To = "";
                        string Type = "";
                        string Depature = "";
                        string Arrival = "";
                        if (xmlReader.Name.Equals("Number") && (xmlReader.Value.Equals(flight.Number) || flight.Number == ""))
                        {
                            Number = xmlReader.Value;
                            xmlReader.MoveToNextAttribute();
                            if (xmlReader.Name.Equals("Company") && (xmlReader.Value.Equals(flight.Company) || flight.Company == ""))
                            {
                                Company = xmlReader.Value;
                                xmlReader.MoveToNextAttribute();
                                if (xmlReader.Name.Equals("From") && (xmlReader.Value.Equals(flight.From) || flight.From == ""))
                                    {
                                    From = xmlReader.Value;
                                    xmlReader.MoveToNextAttribute();
                                    if (xmlReader.Name.Equals("To") && (xmlReader.Value.Equals(flight.To) || flight.To == ""))
                                    {
                                        To = xmlReader.Value;
                                        xmlReader.MoveToNextAttribute();
                                        if (xmlReader.Name.Equals("Type") && (xmlReader.Value.Equals(flight.Type) || flight.Type == ""))
                                        {
                                            Type = xmlReader.Value;
                                            xmlReader.MoveToNextAttribute();
                                            if (xmlReader.Name.Equals("Depature") && (Program.TimeCheck(xmlReader.Value,flight.Depature) || flight.Depature == ""))
                                            {
                                                Depature = xmlReader.Value;
                                                xmlReader.MoveToNextAttribute();
                                                if (xmlReader.Name.Equals("Arrival") && (Program.TimeCheck(xmlReader.Value, flight.Arrival) || flight.Arrival == ""))
                                                {
                                                    Arrival = xmlReader.Value;
                                                    xmlReader.MoveToNextAttribute();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (Number != "" && Company != "" && From != "" && To != "" && Type != "" && Depature != "" && Arrival != "")
                        {
                            result.Add(new Flight(Number, Company, From, To, Type, Depature, Arrival));
                        }
                    }
                }

            }
            xmlReader.Close();
            return result;
        } 
    }
    class AnalizatorXmlLinqToStrategy:IAnalizatorXMLStrategy
    {
       public List<Flight> Search(Flight flight)
        {
            List<Flight> result = new List<Flight>();
            string adress = @"E:\Навчання\ООП\Lab2\Lab2\XMLFile1.xml";
            var doc = XDocument.Load(adress);
            var res = from obj in doc.Descendants("Flight")
                      where (
                      (obj.Attribute("Number").Value.Equals(flight.Number) || (flight.Number == "")) &&
                      (obj.Attribute("Company").Value.Equals(flight.Company) || (flight.Company == "")) &&
                      (obj.Attribute("From").Value.Equals(flight.From) || (flight.From == "")) &&
                      (obj.Attribute("To").Value.Equals(flight.To) || (flight.To == "")) &&
                      (obj.Attribute("Type").Value.Equals(flight.Type) || (flight.Type == "")) &&
                      (obj.Attribute("Depature").Value.Equals(flight.Depature) || (flight.Depature == "")) &&
                      (obj.Attribute("Arrival").Value.Equals(flight.Arrival) || (flight.Arrival == "")))
                      select new
                      {
                          Number = (string)obj.Attribute("Number"),
                          Company = (string)obj.Attribute("Company"),
                          From = (string)obj.Attribute("From"),
                          To = (string)obj.Attribute("To"),
                          Type = (string)obj.Attribute("Type"),
                          Depature = (string)obj.Attribute("Depature"),
                          Arrival = (string)obj.Attribute("Arrival")
                      };
            foreach(var n in res)
            {
                result.Add(new Flight(n.Number, n.Company, n.From, n.To, n.Type, n.Depature, n.Arrival));
            }
            return result;
        }
    }
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static public bool TimeCheck(string attribute, string time)
        {
            if (time != "")
                if (attribute.Substring(0, 2) == time.Substring(0, 2))
                    return true;
            return false;
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
    
