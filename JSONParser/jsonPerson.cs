using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 {
    "firstname" : "Roger",
    "lastname" : "Moore",
    "age" : 89,
    "isAlive": false,
    "address" :
    {
        "streetAddress" : "1 Main Street",
        "city" : "London",
        "postCode" : "N1 3XX"
    },
    "phoneNumbers" :
    [
        { "type" : "home", "number" : "51 9898-5821" },
        { "type" : "mobile", "number" : "51 6566-2903" }
    ]
 }
*/
namespace JSONParser
{
    class jsonPerson
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public double age { get; set; }
        public bool isAlive { get; set; }
        public addr address { get; set; }
        public List<phoneNum> phoneNumbers { get; set; }

        public class addr
        {
            public string streetAddress { get; set; }
            public string city { get; set; }
            public string postCode { get; set; }

        }

        public class phoneNum
        {
            public string type { get; set; }
            public string number { get; set; }
        }
    }
}
