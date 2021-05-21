using System.Collections.Generic;
using System.Linq;
using cwiczenia5_zen_s19743.Models;
using cwiczenia5_zen_s19743.Models.DTOs;

namespace cwiczenia5_zen_s19743.Services
{
    public class TripService : ITripService
    {
        public IEnumerable<TripDto> GetAllTrips()
        {
            var context = new s19743Context();

            //TODO this could be done cleaner
            var trips = context.Trips
                .Select(trip =>
                    new TripDto
                    {
                        Name = trip.Name,
                        Description = trip.Description,
                        DateFrom = trip.DateFrom,
                        DateTo = trip.DateTo,
                        MaxPeople = trip.MaxPeople,
                        Countries = trip.CountryTrips.Select(countryTrip => new CountryDto
                        {
                            Name = countryTrip.IdCountryNavigation.Name
                        }),
                        Clients = trip.ClientTrips.Where(clientTrip => clientTrip.IdTrip == trip.IdTrip)
                            .Select(clientTrip => new ClientDto
                            {
                                FirstName = clientTrip.IdClientNavigation.FirstName,
                                LastName = clientTrip.IdClientNavigation.LastName
                            })
                    })
                .OrderByDescending(dto => dto.DateFrom)
                .ToList();

            return trips;
        }
    }
}