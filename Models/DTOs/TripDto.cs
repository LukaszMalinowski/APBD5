using System;
using System.Collections;
using System.Collections.Generic;

namespace cwiczenia5_zen_s19743.Models.DTOs
{
    public class TripDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public IEnumerable Countries { get; set; }
        public IEnumerable<ClientDto> Clients { get; set; }
    }
}