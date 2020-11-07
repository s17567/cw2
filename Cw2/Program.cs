


using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {


            DateTime czas = DateTime.Now;

            string csv="";
            if (args.Length == 0)
            {






                try
                {
                    csv = System.IO.File.ReadAllText(@"C:\Users\RB\Desktop\Cw2\dane.csv");



               

           
          



            string[] source = File.ReadAllLines(@"C:\Users\RB\Desktop\Cw2\dane.csv");
                   
            XElement cust = new XElement("uczelnia",
                from str in source
                let fields = str.Split(',')
                select new XElement("student",
                    new XAttribute("fname", fields[0]),
                    new XElement("lname", fields[1]),
                    new XElement("studies", fields[2]),
                    new XElement("mode", fields[3]),
                    new XElement("name", fields[4]),
                     new XElement("birthday", fields[5]),
                    new XElement("email", fields[6]),
                    new XElement("mothersname", fields[7]),
                    new XElement("fathersname", fields[8])
                                                        )
                                        );

                    Console.WriteLine(cust);

                    cust.Save(@"C:\Users\RB\Desktop\Cw2\zesult.xml");

                 ///   System.IO.File.WriteAllLines(@"C:\Users\RB\Desktop\Cw2\zesult.xml", (System.Collections.Generic.IEnumerable<string>)cust);

                    XmlDocument json_tobedzie = new XmlDocument();
                   json_tobedzie.LoadXml(@"C:\Users\RB\Desktop\Cw2\zesult.xml");
                    //nie wczytuje sie cos 

                }
                catch (System.Exception)
                {
                    Console.WriteLine("brak pliku, bądź problem z dostępem do pliku");
                    string no_file = " brak pliku, bądź problem z dostępem do pliku  " + czas + "@";
                    no_file = no_file.Replace("@", System.Environment.NewLine);
                    System.IO.File.AppendAllText(@"C:\Users\RB\Desktop\Cw2\log.txt", no_file);
                    //  System.IO.File.AppendAllText(@"log.txt", no_file);


                }
            }






        }
    }
}
