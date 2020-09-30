using System;
using System.Collections.Generic;

namespace ViamericasChallenge.Server.Data.Models
{
    public partial class Status
    {
        public Status()
        {
            Agency = new HashSet<Agency>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Agency> Agency { get; set; }
    }
}
