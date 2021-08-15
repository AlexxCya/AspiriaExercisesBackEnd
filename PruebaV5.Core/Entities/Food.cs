using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PruebaV5.Core.Entities
{
    public class Food
    {
        [JsonPropertyName("dayorder")]
        public string DayOrder { get; set; }
        [JsonPropertyName("dayofweekstr")]
        public string DayOfweekStr { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("locationdesc")]
        public string LocationDesc { get; set; }
        [JsonPropertyName("optionaltext")]
        public string OptionalText { get; set; }
        [JsonPropertyName("locationId")]
        public string LocationId { get; set; }
        [JsonPropertyName("start24")]
        public string Start { get; set; }
        [JsonPropertyName("end24")]
        public string End { get; set; }
        [JsonPropertyName("applicant")]
        public string Applicant { get; set; }
        
    }
}
