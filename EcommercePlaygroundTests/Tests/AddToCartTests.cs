using EcommercePlaygroundTests.Factories;

namespace EcommercePlaygroundTests.Tests
{
    public class AddToCartTests : BaseTests
    {
        [Test]
        public void AssertCartPopup_When_AddElementToCart()
        {
            var product = ProductFactory.IMac106();

            HomePage.Open();
            HomePage.Navigation.Search(product);

            SearchPage.AddProductToCart(product);
        }
    }
}