using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Results
    {
        public string gender { get; set; }
        public Name name { get; set; }

    }
    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }
    public class Users
    {
        public List<Results> results = new List<Results>();
    }
}