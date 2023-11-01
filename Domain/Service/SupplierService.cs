﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service
{
    public class SupplierService : ISupplierService
    {
        private ISuppilerRepository suppilerRepository;
        private IMapper mapper;

        public SupplierService(ISuppilerRepository suppilerRepository, IMapper mapper)
        {
            this.suppilerRepository = suppilerRepository;
            this.mapper = mapper;
        }

        public async Task Create(SupplierRequest entity)
        {
            var supplier = mapper.Map<SupplierRequest, Supplier>(entity);  
            var result = await suppilerRepository.CreateAsync(supplier);
            await suppilerRepository.SaveAsync();
        }

        public Task<SupplierResponse> Create(SupplierResponse entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var suppler = (await suppilerRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (suppler != null)
            {
                var result = suppilerRepository.DeleteAsync(suppler);
                return true;
            }
            return false;
        }

        public async Task<List<SupplierResponse>> GetAll()
        {
            var result = await suppilerRepository.FindAllAsync(p => p.Contracts).ProjectTo<SupplierResponse>(mapper.ConfigurationProvider).ToListAsync();
            return result;
        }

        public Task Update(SupplierResponse entity)
        {
            throw new NotImplementedException();
        }
        public async Task Update (SupplierRequest supplier)
        {
            var result = mapper.Map<SupplierRequest, Supplier>(supplier);
            await suppilerRepository.UpdateAsync(result);
            await suppilerRepository.SaveAsync();   
        }
    }
}
