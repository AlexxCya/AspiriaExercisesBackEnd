using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Core.DTOs
{
    public class FoodDto
    {
        public int DayOrder { get; set; } 
        public string Location { get; set; }
        public string LocationDesc { get; set; }
        public string OptionalText { get; set; }
        public string LocationId { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

    }
}
