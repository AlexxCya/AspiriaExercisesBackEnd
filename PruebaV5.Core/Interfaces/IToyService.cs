using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface IToyService
    {
        PagedList<Toy> GetToys();
        Task InsertToy(Toy toy);
        Task<bool> UpdateToy(Toy toy);
        Task<bool> DeleteToy(int Id);
    }
}
