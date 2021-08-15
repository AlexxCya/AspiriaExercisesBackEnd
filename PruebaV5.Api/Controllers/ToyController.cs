using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaV5.Api.Responses;
using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.DTOs;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;

namespace PruebaV5.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        private readonly IToyService _toyService;
        private readonly IMapper _mapper;
        public ToyController(IToyService toyService, IMapper mapper)
        {
            _toyService = toyService;
            _mapper = mapper;
        }
        /// <summary>
        /// Retrieve all Provinces or Retrieve all Provinces By Country
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ToyDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<ToyDto>>))]
        public IActionResult GetToys()
        {
            var _toys = _toyService.GetToys();
            var _toysDtos = _mapper.Map<IEnumerable<ToyDto>>(_toys);

            var metadata = new Metadata
            {
                TotalCount = _toys.TotalCount,
                PageSize = _toys.PageSize,
                CurrentPage = _toys.CurrentPage,
                TotalPages = 1,
                HasNextPage = _toys.HasNextPage,
                HasPreviousPage = _toys.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<ToyDto>>(_toysDtos, true)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        /// <summary>
        /// Add Toy
        /// </summary>
        /// <param name="toyDto">Filters to apply</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Toy(ToyDto toyDto)
        {
            var _toy = _mapper.Map<Toy>(toyDto);
            await _toyService.InsertToy(_toy);

            toyDto = _mapper.Map<ToyDto>(_toy);

            var response = new ApiResponse<ToyDto>(toyDto, true);
            return Ok(response);
        }
        /// <summary>
        /// Update Toy
        /// </summary>
        /// <param name="Id">Filters to apply</param>
        /// <param name="toyDto">Filters to apply</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int Id, ToyDto toyDto)
        {
            var _toy = _mapper.Map<Toy>(toyDto);
            _toy.Id = Id;

            var result = await _toyService.UpdateToy(_toy);
            var response = new ApiResponse<bool>(result, result);
            return Ok(response);
        }
        /// <summary>
        /// Delete Toy
        /// </summary>
        /// <param name="Id">Filters to apply</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _toyService.DeleteToy(Id);
            var response = new ApiResponse<bool>(result, result);
            return Ok(response);
        }
    }
}
