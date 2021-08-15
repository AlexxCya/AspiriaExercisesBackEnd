using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Core.Entities
{
    public partial class Toy : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}
