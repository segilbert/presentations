using System.Collections.Generic;

namespace StriderCupRacing.Models
{
    public class Race
	{
		public int RaceId {get; set;}
		public string Name {get; set;}
		public string Description {get; set;}
		public string Country {get; set;}
		public string State {get; set;}
		public string City {get; set;}
		public string Rating {get; set;}
		public string Status {get; set;}
		public System.DateTime StartDate {get; set;}
		public System.DateTime EndDate {get; set;}
		public string Type {get; set;}

        public IList<Motto> Mottos { get; set; }

        public RiderMembershipEnum SanctionedBy { get; set; }
    }
}