using System;
using System.Collections.Generic;

namespace ViamericasChallenge.Server.Data.Models
{
    public partial class City
    {
        public City()
        {
            Agency = new HashSet<Agency>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Agency> Agency { get; set; }
    }
}
