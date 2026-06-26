using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ReadF
{ //json
    class Person
    {
        public string Name {  get; set; }
        public int Age {  get; set; }
        public string City { get; set; }

    }
    internal class Class2
    {
        
        List<Person> people;


        public void ReadJson(string path)
        {
           string json = File.ReadAllText(path);
            people = JsonSerializer.Deserialize<List<Person>>(json);

            foreach (Person p in people)
            {
                Console.WriteLine(p.Name + " " + p.Age + " " + p.City);
            }
        }
        public void WriteJson(string path)
        {
            //List<Person> newPeople = new List<Person>
            //{
            //    new Person{ Name = "okfk", Age =  222, City = "fjfjf"}
            //}; 
            // запись в новый файл
           string json = JsonSerializer.Serialize(people);
            File.WriteAllText(path, json);
        }
}
}
