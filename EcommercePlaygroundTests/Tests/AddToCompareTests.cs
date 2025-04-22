using EcommercePlaygroundTests.Factories;
using EcommercePlaygroundTests.Pages;

namespace EcommercePlaygroundTests.Tests
{
    public class AddToCompareTests : BaseTests
    {
        [Test]
        public void AssertComparePage_When_AddTwoElementsToCompare()
        {
            var imac = ProductFactory.IMac106();
            var htc = ProductFactory.Htc28();

            HomePage.Open();
            HomePage.Navigation.Search(imac);
            SearchPage.AddToCompare(imac);
            SearchPage.Search(htc);
            SearchPage.AddToCompare(htc);
            SearchPage.Navigation.ClickOnCompareButton();

            ComparePage.AssertProducts(imac, htc);
        }
    }
}