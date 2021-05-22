using System;
using System.Collections.Generic;
using System.Linq;
using cwiczenia5_zen_s19743.Exceptions;
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

        public void RegisterClientOnTrip(TripRegistrationDto registration)
        {
            var context = new s19743Context();

            var client = context.Clients.SingleOrDefault(c => c.Pesel == registration.Pesel)
                         ?? AddNewClient(registration, context);

            if (IsClientAlreadySigned(registration, client, context))
            {
                throw new TripException("Client is already signed on a trip.");
            }

            if (TripDoesntExist(registration, context))
            {
                throw new TripException("Trip doesn't exist.");
            }

            var clientTrip = CreateClientTripFromRequest(registration, client);

            context.ClientTrips.Add(clientTrip);

            context.SaveChanges();
        }

        private ClientTrip CreateClientTripFromRequest(TripRegistrationDto registration, Client client)
        {
            return new()
            {
                IdClient = client.IdClient,
                IdTrip = registration.IdTrip,
                PaymentDate = registration.PaymentDate,
                RegisteredAt = DateTime.Now
            };
        }

        private static bool TripDoesntExist(TripRegistrationDto registration, s19743Context context)
        {
            return !context.Trips.Any(t => t.IdTrip == registration.IdTrip);
        }

        private static bool IsClientAlreadySigned(TripRegistrationDto registration, Client client,
            s19743Context context)
        {
            return context.ClientTrips.Any(trip =>
                trip.IdClient == client.IdClient && trip.IdTrip == registration.IdTrip);
        }

        private static Client AddNewClient(TripRegistrationDto registration, s19743Context context)
        {
            Client client;
            client = new Client
            {
                IdClient = context.Clients.Max(c => c.IdClient) + 1,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.Email,
                Telephone = registration.Telephone,
                Pesel = registration.Pesel,
                ClientTrips = new HashSet<ClientTrip>()
            };

            context.Clients.Add(client);
            return client;
        }
    }
}