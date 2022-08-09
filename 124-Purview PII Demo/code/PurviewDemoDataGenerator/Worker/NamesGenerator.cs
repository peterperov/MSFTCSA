using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace PurviewDemoDataGenerator.Worker
{
    public class NamesGenerator
    {

        public string visa              = "4111 1111 1111 1111";
        public string masterCard1       = "5500 0000 0000 0004"; 
        public string masterCard2       = "5424 0000 0000 0015";
        public string americanExpress1  = "3782 8224 6310 005"; 
        public string americanExpress2  = "3400 0000 0000 009"; 
        public string americanExpress3  = "3700 0000 0000 002";

        public string[] creditCards; 


        public string firstNames = @"W:\GITHUB\MSFTCSA\124-Purview PII Demo\NamesDatabases\first names\us.txt";
        public string lastNames = @"W:\GITHUB\MSFTCSA\124-Purview PII Demo\NamesDatabases\surnames\ie.txt";


        public NamesGenerator()
        {
            creditCards = new string[] { visa, masterCard1, masterCard2, americanExpress1, americanExpress2, americanExpress3};  
        }


        public List<Person> LoadData(int count = 1000)
        {
            List<string> first = File.ReadAllLines(firstNames).ToList();
            List<string> last = File.ReadAllLines(lastNames).ToList();

            var firstCount = first.Count; 
            var lastCount = last.Count;
            var ccCount = creditCards.Length;


            Console.WriteLine("Maximums {0} {1} {2}", firstCount, lastCount, ccCount);

            var list = new List<Person>();

            var rnd = new Random(DateTime.Now.Millisecond); 

            for ( int i = 0; i < count; i++ )
            {

                var f = rnd.Next(0, firstCount);
                var l = rnd.Next(0, lastCount);
                var c = rnd.Next(0, ccCount);

                // Console.WriteLine("{0} {1} {2}", f, l, c); 

                list.Add(new Person(
                    first[f],
                    last[l],
                    creditCards[c]
                    )
                );
            }

            return list; 

        }


        public void GenerateInserts(List<Person> list)
        {
            foreach ( var p in list )
            {
                var str = string.Format("INSERT INTO Users (FullName, Email, CreditCard) VALUES ('{0}', '{1}', '{2}');",
                    SqlEscape(p.FullName),
                    SqlEscape(p.Email),
                    SqlEscape(p.CreditCard)
                    );

                Console.WriteLine(str); 
            }
        }

        public string SqlEscape(string str)
        {
            if (String.IsNullOrEmpty(str)) return str;
            return str.Replace("'", "''"); 
        }




    }

    public class Person
    {

        public Person()
        {

        }

        public Person(string firstName, string lastName, string creditCard)
        {
        
            FirstName = firstName;
            LastName = lastName;
            Email = String.Format("{0}.{1}@testdata.net", firstName, lastName); 
            CreditCard = creditCard;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string CreditCard { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public string ToLine()
        {
            return string.Format("{0} {1}, {2}, {3}", FirstName, LastName, Email, CreditCard); 
        }

    }

}
