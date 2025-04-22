using EcommercePlaygroundTests.Factories;

namespace EcommercePlaygroundTests.Tests
{
    public class AddToCartTests : BaseTests
    {
        [Test]
        public void AssertCartPopup_When_AddElementToCart()
        {
            var imac = ProductFactory.IMac106();
            var htc = ProductFactory.Htc28();

            HomePage.Open();
            HomePage.Navigation.Search(imac);
            SearchPage.AddToCart(imac);
            SearchPage.Search(htc);
            SearchPage.AddToCart(htc);
            SearchPage.Navigation.ClickOnCartButton();

            SearchPage.CartPopUp.AssertCart(imac, htc);
        }
    }
}