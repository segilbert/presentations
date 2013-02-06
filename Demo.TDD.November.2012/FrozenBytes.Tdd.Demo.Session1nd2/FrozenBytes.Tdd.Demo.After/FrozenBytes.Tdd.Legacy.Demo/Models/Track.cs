using System.Collections.Generic;

namespace StriderCupRacing.Models
{

    public class Track
	{
		public int TrackId {get; set;}
		public string Name {get; set;}
		public string Description {get; set;}
		public string Status {get; set;}
		public string Rating {get; set;}
		public string District {get; set;}

        public IList<Race> Races { get; set; }
	}
}