namespace EcommercePlaygroundTests.Extensions
{
    public static class EnumberableExtensions
    {
        public static void ShouldBeEquivalentBy<T, TKey>(this IEnumerable<T> actual, IEnumerable<T> expected, Func<T, TKey> selector)
        {
            var comparer = new LambdaComparer<T, TKey>(selector);
            Assert.That(actual, Is.EquivalentTo(expected).Using(comparer));
        }
    }
}
