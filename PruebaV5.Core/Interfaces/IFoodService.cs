using PruebaV5.Core.DTOs;
using PruebaV5.Core.Entities;
using PruebaV5.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface IFoodService
    {
        Task<List<Food>> GetAll(FoodFilter filter);
    }
}
