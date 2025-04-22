using EcommercePlaygroundTests.Models;

namespace EcommercePlaygroundTests.Factories
{
    public static class ProductFactory
    {
        public static Product IMac106() { 
            var product = new Product();
            product.Name = "iMac";
            product.Id = 106;
            product.CompareImage = "https://ecommerce-playground.lambdatest.io/image/cache/catalog/maza/demo/mz_poco/megastore-2/product/10-90x90.webp";
            product.Price = 170;
            product.Model = "Product 14";
            product.Brand = "Apple";
            product.Availability = "Out Of Stock";
            product.Summary = "Just when you thought iMac had everything, now there´s even more. More powerful Intel Core 2 Duo processors. And more memory standard. Combine this with Mac OS X Leopard and iLife ´08, and it´s mor..";
            product.Weight = "5.00kg";
            product.Dimensions = "0.00cm x 0.00cm x 0.00cm";


            return product;
        }

        public static Product Htc28()
        {
            var product = new Product();
            product.Name = "HTC Touch HD";
            product.Id = 28;
            product.CompareImage = "https://ecommerce-playground.lambdatest.io/image/cache/catalog/maza/demo/mz_poco/megastore-2/product/1-90x90.webp";
            product.Price = 146;
            product.Model = "Product 1";
            product.Brand = "HTC";
            product.Availability = "Out Of Stock";
            product.Summary = "HTC Touch - in High Definition. Watch music videos and streaming content in awe-inspiring high definition clarity for a mobile experience you never thought possible. Seductively sleek, the HTC Touc..";
            product.Weight = "146.40g";
            product.Dimensions = "0.00cm x 0.00cm x 0.00cm";

            return product;
        }
    }
}