using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Flight
    {
        public string Number { get; set; }
        public string Company { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public string Depature { get; set; }
        public string Arrival { get; set; }
        public Flight(string number, string company, string from, string to, string type, string depature, string arrival)
        {
            Number = number;
            Company = company;
            From = from;
            To = to;
            Type = type;
            Depature = depature;
            Arrival = arrival;
        }
        public Flight()
        {
            Number = "";
            Company = "";
            From = "";
            To = "";
            Type = "";
            Depature = "";
            Arrival = "";
        }
    }
}
