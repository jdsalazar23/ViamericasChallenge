using System;
using System.Collections.Generic;

namespace ViamericasChallenge.Server.Data.Models
{
    public partial class Agency
    {
        public string AgencyId { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Status Status { get; set; }
    }
}
