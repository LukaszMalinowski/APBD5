using System;

namespace cwiczenia5_zen_s19743.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(int idClient) : base("Client with id " + idClient + " not found.")
        {
        }
    }
}