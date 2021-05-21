using System;
using System.Collections.Generic;

#nullable disable

namespace cwiczenia5_zen_s19743.Models
{
    public partial class ClientTrip
    {
        public int IdClient { get; set; }
        public int IdTrip { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
    }
}
