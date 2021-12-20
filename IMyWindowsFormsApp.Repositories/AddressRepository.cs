using IMyWindowsFormsApp.Data.DB;
using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    internal class AddressRepository : IAddressRepository
    {
        private readonly IDbContext _dbContext;

        public AddressRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Address model)
        {
            _dbContext.Addresses.Add(model);
        }

        public Address Get(Guid id)
        {
            return _dbContext.Addresses.FirstOrDefault(x => x.StudentId == id);
        }

        public void Remove(Address model)
        {
            _dbContext.Addresses.Remove(model);
        }

        public void Update(Address model)
        {
            Address temp = _dbContext.Addresses.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            _dbContext.Addresses.Remove(temp);
            _dbContext.Addresses.Add(model);
        }
    }
}
