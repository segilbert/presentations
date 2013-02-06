namespace StriderCupRacing.Models
{
    using System.Collections.Generic;

    public class Motto
    {
        private IList<Lane> _lanes;

        public int MottoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RiderClassification { get; set; }

        public IList<Lane> Lanes
        {
            get
            {
                return _lanes;
            }
        }

        public class Lane
        {
            public int LaneId { get; set; }
            public Rider Rider { get; set; }
            public int FinishSpot { get; set; }
        }

        public Motto()
        {
            this._lanes = new List<Lane>();
            for (int i = 0; i < 9; i++)
                Lanes.Add(new Lane() { LaneId = i });
        }

    }
}