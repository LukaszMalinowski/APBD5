using System.Collections.Generic;
using cwiczenia5_zen_s19743.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia5_zen_s19743.Services
{
    public class TripService : ITripService
    {
        private readonly DbContext _dbContext;

        public TripService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TripDto> GetAllTrips()
        {
            throw new System.NotImplementedException();
        }
    }
}