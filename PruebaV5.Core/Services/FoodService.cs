using PruebaV5.Core.Entities;
using PruebaV5.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PruebaV5.Core.Interfaces;
using System.Linq;
using PruebaV5.Core.QueryFilters;

namespace PruebaV5.Core.Services
{
    public class FoodService: IFoodService
    {
        private readonly HttpClient _client;
        public FoodService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://data.sfgov.org/resource/jjew-r69b.json")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<Food>> GetAll(FoodFilter filter)
        {
            List<Food> foodsFinal = new List<Food>();
            try
            {
                var foods = await _client.GetFromJsonAsync<List<Food>>("");

                var hr = GetValue(filter.Hour.Split(':')[0]);
                var min = GetValue(filter.Hour.Split(':')[1]);
                
                TimeSpan hour = new TimeSpan(hr, min, 0);

                foreach (var food in foods)
                {
                    var hrStart = GetValue(food.Start.Split(':')[0]);
                    var minStart = GetValue(food.Start.Split(':')[1]);
                    var hrEnd = GetValue(food.End.Split(':')[0]);
                    var minEnd = GetValue(food.End.Split(':')[1]);

                    TimeSpan start = new TimeSpan(hrStart, minStart, 0);
                    TimeSpan end = new TimeSpan(hrEnd, minEnd, 0);

                    if (hour >= start && hour <= end && food.DayOrder == filter.DayOrder.ToString())
                        foodsFinal.Add(food);

                }
            }
            catch (Exception ex)
            {
                throw new BussinesException(ex.Message);
            }

            return foodsFinal.OrderBy(x => x.Applicant).ToList();
        }

        private int GetValue(string value)
        {
            string result = string.Empty;

            var firstPosition = value.Substring(0);

            if (firstPosition.Equals("0"))
                result = value.Substring(1);
            else
                result = value;

            return int.Parse(result);
        }
    }
}
