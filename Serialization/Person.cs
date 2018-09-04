using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    /*Attribute shows you that 
    objects(classes, methods and others)
    are serializable*/
    [Serializable]   
    public class Person
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public Person() { } //Empty constructor for Xml Serialization
        public Person(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }

        [NonSerialized]
        public string AccNumber;
    }
}