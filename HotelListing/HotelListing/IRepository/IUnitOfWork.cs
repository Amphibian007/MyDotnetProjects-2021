using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository <Country> Countries { get; }
        public IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
