using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaV5.Api.Responses;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;

namespace PruebaV5.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        //private readonly IMapper _mapper;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
            //_mapper = mapper;
        }
        /// <summary>
        /// Get Foods By Filters
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get([FromQuery] FoodFilter filters)
        {
            var _toys = _foodService.GetAll(filters).GetAwaiter().GetResult();
            
            var response = new ApiResponse<List<Food>>(_toys, true);
            
            return Ok(response);
        }
    }
}
