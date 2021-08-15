using Microsoft.Extensions.Options;
using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Exceptions;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Core.Services
{
    public class ToyService: IToyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public ToyService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        //public Task<Toy> GetToy(long Id)
        //{
        //    throw new NotImplementedException();
        //}

        public PagedList<Toy> GetToys()
        {
            
            var _toys = _unitOfWork.ToyRepository.GetAll();

            
            var _pagedToys = PagedList<Toy>.Create(_toys, 1, _toys.Count());

            return _pagedToys;
        }

        public async Task InsertToy(Toy toy)
        {
            var _toyExists = _unitOfWork.ToyRepository.GetAll().Where(x => x.Name.ToUpper().Equals(toy.Name.ToUpper()) &&
                                x.Company.ToUpper().Equals(toy.Company.ToUpper())).FirstOrDefault();
            if (_toyExists != null)
            {
                throw new BussinesException("Ya Existe un Juguete con ese Nombre y Comapñia");
            }
            else
            {
                await _unitOfWork.ToyRepository.Add(toy);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateToy(Toy toy)
        {
            _unitOfWork.ToyRepository.Update(toy);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteToy(int Id)
        {
            await _unitOfWork.ToyRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
