using System.Collections;
using System.Collections.Generic;
using cwiczenia5_zen_s19743.Models.DTOs;

namespace cwiczenia5_zen_s19743.Services
{
    public interface ITripService
    {
        public IEnumerable<TripDto> GetAllTrips();
    }
}