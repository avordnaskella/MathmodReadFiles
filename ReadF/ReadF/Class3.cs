using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ReadF
{
  public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    internal class Class3
    {
        public List<Person2> people2;

        public void ReadXML(string path) 
        { 
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person2>));

            using (StreamReader sr = new StreamReader(path)) 
            {
                people2 = (List<Person2>)serializer.Deserialize(sr);
            }

            foreach (Person2 p in people2)
            {
                Console.WriteLine(p.Name + " " + p.City + " " + p.Age);
            }
        }

        public void WriteXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer (typeof(List<Person2>));
            using (StreamWriter sr = new StreamWriter(path)) 
            { 
                serializer.Serialize(sr, people2);
            }
        }

    }
}  
