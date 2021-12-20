using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Repositories;
using System;
using System.Collections.Generic;

namespace IMyWindowsFormsApp.Services
{
    internal class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public void Add(Address model)
        {
            _addressRepository.Add(model);
        }
        public Address Get(Guid id)
        {
            return _addressRepository.Get(id);
        }

        public void Remove(Address model)
        {
            _addressRepository.Remove(model);
        }
        public void Update(Address model)
        {
            _addressRepository.Update(model);
        }
    }
}
