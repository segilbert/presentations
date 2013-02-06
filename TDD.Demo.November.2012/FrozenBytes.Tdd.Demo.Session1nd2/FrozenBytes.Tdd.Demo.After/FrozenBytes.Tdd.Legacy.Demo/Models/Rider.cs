using System;

namespace StriderCupRacing.Models
{
    using System.Collections.Generic;

    public class Rider
    {
        public int RiderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum GenderEnum { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }

        public string RiderClassification { get; set; }

        public RiderSkillLevelEnum SkillLevelEnum { get; set; }

        public IList<RiderMembershipEnum> Memberships { get; set; }
        
    }
}