using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePlaygroundTests.Factories
{
    internal class TestClasss
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; internal set; }
        public decimal Price { get; internal set; }
    }
}
