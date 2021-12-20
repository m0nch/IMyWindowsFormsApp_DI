using IMyWindowsFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Repositories
{
    public interface IAddressRepository
    {
        void Add(Address model);
        Address Get(Guid id);
        void Remove(Address model);
        void Update(Address model);
    }
}
