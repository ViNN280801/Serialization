using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationInBinary();
            SerializationInSOAP();
            SerializationInXml();

            DesirializationInJson(5);

            Console.WriteLine("Program completed successfully!");
        }

        /*Types of serialization 
        (Practically all of them are identity except Xml {1 small correction})*/
        static void SerializationInBinary()
        {
            //Filling class Person
            Person person = new Person("Vladislav", 2001);

            //Creating formatter as Binary
            BinaryFormatter formatter = new BinaryFormatter();

            //Serialization
            using (FileStream fs = new FileStream("PersonBinary.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

            //Desirialization
            using (FileStream fs = new FileStream("PersonBinary.dat", FileMode.OpenOrCreate))
            {
                Person obj = formatter.Deserialize(fs) as Person;
            }
        }
        static void SerializationInSOAP()
        {
            //Filling class Person
            Person person = new Person("Vladislav", 2001);

            //Creating formatter as Binary
            SoapFormatter formatter = new SoapFormatter();

            //Serialization
            using (FileStream fs = new FileStream("PersonSOAP.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

            //Desirialization
            using (FileStream fs = new FileStream("PersonSOAP.dat", FileMode.OpenOrCreate))
            {
                Person obj = formatter.Deserialize(fs) as Person;
            }
        }
        static void SerializationInXml()
        {
            //Filling class Person
            Person person = new Person("Vladislav", 2001);

            //Creating formatter as Binary
            XmlSerializer formatter = new XmlSerializer(typeof(Person)); //Necessary is TYPEOF

            //Serialization
            using (FileStream fs = new FileStream("PersonXml.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }

            //Desirialization
            using (FileStream fs = new FileStream("PersonXml.xml", FileMode.Open))
            {
                Person obj = formatter.Deserialize(fs) as Person;
            }
        }
        static void DesirializationInJson(int countUser)
        {
            //This URL is creating random user
            string url = "https://randomuser.me/api/?results=" + countUser;

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                //Converting "array" in Json format
                var data = Newtonsoft.Json.
                    JsonConvert.DeserializeObject<Users>(json); 

            }
        }
    }
}