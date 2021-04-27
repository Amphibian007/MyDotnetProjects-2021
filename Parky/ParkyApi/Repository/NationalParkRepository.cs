using ParkyApi.Data;
using ParkyApi.Models;
using ParkyApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyApi.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NationalParkRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _dbContext.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _dbContext.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            var park=_dbContext.NationalParks.FirstOrDefault(p => p.Id == nationalParkId);
            return park;
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            var parks = _dbContext.NationalParks.OrderBy(p=>p.Name).ToList();
            return parks;
        }

        public bool NationalParkExists(int id)
        {
            var value = _dbContext.NationalParks.Any(p => p.Id == id);
            return value;
        }

        public bool NationalParkExists(string name)
        {
            var value = _dbContext.NationalParks.Any(p => p.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool Save()
        {
          return  _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _dbContext.NationalParks.Update(nationalPark);
            return Save();

        }
    }
}
