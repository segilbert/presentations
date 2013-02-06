namespace StriderCupRacing.Models
{
    using System.Collections.Generic;

    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public IList<Rider> Riders { get; set; }
        public IList<Race> RegisteredRaces { get; set; }

    }
}