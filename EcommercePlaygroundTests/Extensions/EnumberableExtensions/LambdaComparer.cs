namespace EcommercePlaygroundTests.Extensions
{
    public class LambdaComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _selector;

        public LambdaComparer(Func<T, TKey> selector)
        {
            _selector = selector;
        }

        public bool Equals(T x, T y)
        {
            return _selector(x)?.Equals(_selector(y)) ?? false;
        }

        public int GetHashCode(T obj)
        {
            return _selector(obj)?.GetHashCode() ?? 0;
        }
    }

}
