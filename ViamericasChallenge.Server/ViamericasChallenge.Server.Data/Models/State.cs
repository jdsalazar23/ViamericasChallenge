using System;
using System.Collections.Generic;

namespace ViamericasChallenge.Server.Data.Models
{
    public partial class State
    {
        public State()
        {
            Agency = new HashSet<Agency>();
        }

        public int StateId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Agency> Agency { get; set; }
    }
}
