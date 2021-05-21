using System.Linq;
using cwiczenia5_zen_s19743.Exceptions;
using cwiczenia5_zen_s19743.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia5_zen_s19743.Services
{
    public class ClientService : IClientService
    {
        public void DeleteClient(int idClient)
        {
            var context = new s19743Context();

            var client = context.Clients.SingleOrDefault(dbClient => dbClient.IdClient == idClient);

            if (client == null)
            {
                throw new ClientNotFoundException(idClient);
            }

            var clientHasTrips = context.ClientTrips.Any(trip => trip.IdClient == idClient);

            if (clientHasTrips)
            {
                throw new ClientHasTripsException(idClient);
            }

            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}