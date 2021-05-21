using System;

namespace cwiczenia5_zen_s19743.Exceptions
{
    public class ClientHasTripsException : Exception
    {
        public ClientHasTripsException(int idClient) : base("Client with id " + idClient +
                                                            " has trips so can't be deleted.")
        {
        }
    }
}