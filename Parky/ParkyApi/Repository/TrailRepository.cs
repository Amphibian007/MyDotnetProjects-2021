using Microsoft.EntityFrameworkCore;
using ParkyApi.Data;
using ParkyApi.Models;
using ParkyApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyApi.Repository
{
    public class TrailRepository:ITrailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TrailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateTrail(Trail trail)
        {
            _dbContext.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _dbContext.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            var trail = _dbContext.Trails.Include(c=>c.NationalPark).FirstOrDefault(p => p.Id == trailId);
            return trail;
        }

        public ICollection<Trail> GetTrails()
        {
            var trails = _dbContext.Trails.Include(c=>c.NationalPark).OrderBy(p => p.Name).ToList();
            return trails;
        }

        public bool TrailExists(int id)
        {
            var value = _dbContext.Trails.Any(p => p.Id == id);
            return value;
        }

        public bool TrailExists(string name)
        {
            var value = _dbContext.Trails.Any(p => p.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _dbContext.Trails.Update(trail);
            return Save();

        }

        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
          var trailsInNationalPark =_dbContext.Trails.Include(c => c.NationalPark).Where(c => c.NationalParkId == npId).ToList();
            return trailsInNationalPark;
        }
    }
}
