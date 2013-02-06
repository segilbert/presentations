using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StriderCupRacing.Models
{
    public class Rider
    {
        public int RiderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
    }

}