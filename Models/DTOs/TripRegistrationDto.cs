using System;

namespace cwiczenia5_zen_s19743.Models.DTOs
{
    public class TripRegistrationDto
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Pesel { get; set; }
        public int IdTrip { get; set; }
        public string TripName { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}