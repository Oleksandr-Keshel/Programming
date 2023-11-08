using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        XDocument XmlDoc = new XDocument(
            new XDeclaration("1.0","UTF-8","yes"),
            new XElement("Abiturients",
                new XElement("Abiturient",
                    new XElement("Surname", "O'Connel"),
                    new XElement("Sex","Male"),
                    new XElement("GraduationYear", "2022"),
                    new XElement("TotalPoint","600") ),

                new XElement("Abiturient",
                    new XElement("Surname", "Henry"),
                    new XElement("Sex","Male"),
                    new XElement("GraduationYear", "2022"),
                    new XElement("TotalPoint","340") ),

                new XElement("Abiturient",
                    new XElement("Surname", "Holland"),
                    new XElement("Sex","Male"),
                    new XElement("GraduationYear", "2023"),
                    new XElement("TotalPoint","323") ),

                new XElement("Abiturient",
                    new XElement("Surname", "Silva"),
                    new XElement("Sex","Female"),
                    new XElement("GraduationYear", "2022"),
                    new XElement("TotalPoint","540") ),

                new XElement("Abiturient",
                    new XElement("Surname", "William"),
                    new XElement("Sex","Female"),
                    new XElement("GraduationYear", "2023"),
                    new XElement("TotalPoint","250") ),
                    
                new XElement("Abiturient",
                    new XElement("Surname", "Johanson"),
                    new XElement("Sex","Female"),
                    new XElement("GraduationYear", "2023"),
                    new XElement("TotalPoint","490") ) ) );

        XmlDoc.Save(@"/Users/oleksandr/Desktop/ProgrammingCSharp/My Labs/lab3/Vstup.xml");


        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Vstup.xml");

        XmlElement root = xmlDoc.DocumentElement;
        if(root != null)
        {
            //Read the file in console
            Console.WriteLine("Abiturients: ");
            XmlNodeList abiturients = root.GetElementsByTagName("Abiturient");

            foreach (XmlNode abiturient in abiturients)
            {
                string surname = abiturient.SelectSingleNode("Surname").InnerText;
                string sex = abiturient.SelectSingleNode("Sex").InnerText;
                string graduationYear = abiturient.SelectSingleNode("GraduationYear").InnerText;
                string totalPoint = abiturient.SelectSingleNode("TotalPoint").InnerText;
                Console.WriteLine($"Surname: {surname}, Sex: {sex}, Graduation year: {graduationYear}, Total points: {totalPoint}");
            }

            System.Console.WriteLine("--------------");

            //Select abiturient by name
            Console.Write("Type surname of abiturient:  ");
            string inputSurname = Console.ReadLine();
            foreach (XmlNode abiturient in abiturients)
            {
                string surname = abiturient.SelectSingleNode("Surname").InnerText;

                if(surname == inputSurname){
                    string sex = abiturient.SelectSingleNode("Sex").InnerText;
                    string graduationYear = abiturient.SelectSingleNode("GraduationYear").InnerText;
                    string totalPoint = abiturient.SelectSingleNode("TotalPoint").InnerText;

                    Console.WriteLine("Information about specified abiturient:");
                    Console.WriteLine($"Surname: {surname}, Sex: {sex}, Graduation year: {graduationYear}, Total points: {totalPoint}");
                }
            }

            System.Console.WriteLine("--------------");

            //Select abiturient by graduation year and min point
            Console.Write("Type graduation year:  ");
            int inputYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type min point:  ");
            int inputMinPoint = Convert.ToInt32(Console.ReadLine());
            int numOfSelectedAbitur = 0;
            foreach (XmlNode abiturient in abiturients)
            {
                int graduationYear = Convert.ToInt32(abiturient.SelectSingleNode("GraduationYear").InnerText);
                int totalPoint = Convert.ToInt32(abiturient.SelectSingleNode("TotalPoint").InnerText);

                if(graduationYear == inputYear && totalPoint >= inputMinPoint){
                    numOfSelectedAbitur++;   
                }
            }
            Console.WriteLine("Number of abiturients: " + numOfSelectedAbitur);



        }
    
    
    
    }
}