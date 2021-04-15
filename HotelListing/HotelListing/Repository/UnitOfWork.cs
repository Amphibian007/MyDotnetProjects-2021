using HotelListing.Data;
using HotelListing.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDbContext _hotelDbContext;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        public UnitOfWork(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_hotelDbContext);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_hotelDbContext);

        public void Dispose()
        {
            _hotelDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
           await _hotelDbContext.SaveChangesAsync();
        }
    }
}
