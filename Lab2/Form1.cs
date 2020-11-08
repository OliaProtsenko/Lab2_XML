using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBoxesAddLists();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void SpecialComboBoxAddList(List<string>list,ComboBox box)
        {
           
        foreach (string str in list)
               box.Items.Add(str);
            

        }
        private void ComboBoxesAddLists()
        {
            List<string> numbers = new List<string>(){ "AUA381",
            "AUA382","THY0441","THY0442","LOT765","LOT763","LOT764","LOT765","LOT766","PGT420","PGT421","PGT1760","PGT1761","RYR7858","RYR7859",
                "RYR7858","RYR7859","RYR7856"};
            List<string> companies = new List<string>() { "Austrian Airlines", "Turkish Airlines", "LOT Polish Airlines", "Pegasus Airlines", "Ryanair" };
            List<string> from = new List<string>() { "Lviv", "Warsaw", "Vienna", "Istanbul", "Bodrum", "Kyiv", "London Stansted" };
            List<string> to = from;
            List<string> type = new List<string>() { "DH8D", "076", "A321", "180", "118", "E195", "B738", "189" };
            List<string> depature = new List<string>() { "00:00-01:00","01:00-02:00","02:00-03:00","03:00-04:00","04:00-05:00","05:00-06:00","06:00-07:00","07:00-08:00","08:00-09:00",
            "09:00-10:00","10:00-11:00","12:00-13:00","13:00-14:00","14:00-15:00","15:00-16:00","16:00-17:00","17:00-18:00","18:00-19:00","19:00-20:00","20:00-21:00","21:00-22:00","22:00-23:00","23:00-00:00"};
            List<string> arrival = depature;
            SpecialComboBoxAddList(numbers, NumberComboBox);
            SpecialComboBoxAddList(companies, CompanyComboBox);
            SpecialComboBoxAddList(from, FromComboBox);
            SpecialComboBoxAddList(to, ToComboBox);
            SpecialComboBoxAddList(type, TypeComboBox);
            SpecialComboBoxAddList(depature, DepatureComboBox);
            SpecialComboBoxAddList(arrival, ArrivalComboBox);
        }
        private void FromComboBoxAddList()
        {
           
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            ResultRichTextBox.Text = "";
            Flight flight = new Flight();
            IfChecked(flight);
            IAnalizatorXMLStrategy analizator = new AnalizatorXmlDOMStrategy();//за замовчуванням;
            if (radioButtonDom.Checked)
                analizator = new AnalizatorXmlDOMStrategy();
            if (radioButtonSax.Checked)
                analizator = new AnalizatorXmlSAXStrategy();
            if (radioButtonLinq.Checked)
                analizator = new AnalizatorXmlLinqToStrategy();
            List<Flight> res = analizator.Search(flight);
            Output(res);

        }
        private void IfChecked(Flight flight)
        {
            if (NumberCheckBox.Checked)
                flight.Number = NumberComboBox.SelectedItem.ToString();
            if (CompanyCheckBox.Checked)
                flight.Company = CompanyComboBox.SelectedItem.ToString();
            if (FromCheckBox.Checked)
                flight.From = FromComboBox.SelectedItem.ToString();
            if (ToCheckBox.Checked)
                flight.To = ToComboBox.SelectedItem.ToString();
            if (TypeCheckBox.Checked)
                flight.Type = TypeComboBox.SelectedItem.ToString();
            if (DepatureCheckBox.Checked)
                flight.Depature = DepatureComboBox.SelectedItem.ToString();
            if (ArrivalCheckBox.Checked)
                flight.Arrival = ArrivalComboBox.SelectedItem.ToString();
        }
        private void Output(List<Flight> res)
        {
            foreach (Flight flight1 in res)
            {
                ResultRichTextBox.Text += "Number " + flight1.Number + "\n";
                ResultRichTextBox.Text += "Company " + flight1.Company + "\n";
                ResultRichTextBox.Text += "From " + flight1.From + "\n";
                ResultRichTextBox.Text += "To " + flight1.To + "\n";
                ResultRichTextBox.Text += "Type " + flight1.Type + "\n";
                ResultRichTextBox.Text += "Depature " + flight1.Depature + "\n";
                ResultRichTextBox.Text += "Arrival " + flight1.Arrival + "\n"+"\n";
                
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transform();
        }
        private void transform()
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            string adress = @"E:\Навчання\ООП\Lab2\Lab2\Flights.xsl";
            xct.Load(adress);
            string fXML = @"E:\Навчання\ООП\Lab2\Lab2\XMLFile1.xml";
            string fHTML = @"E:\Навчання\ООП\Lab2\Lab2\Flights.html";
            xct.Transform(fXML, fHTML);

        }
    }
    
}
