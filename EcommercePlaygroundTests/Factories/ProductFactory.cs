using EcommercePlaygroundTests.Models;

namespace EcommercePlaygroundTests.Factories
{
    public static class ProductFactory
    {
        public static Product IMac106() { 
            var product = new Product();
            product.Name = "iMac";
            product.Id = 106;

            return product;
        }
    }
}
