namespace HIVBackend.Interfaces
{
    public class DictionaryEqualityComparer : IEqualityComparer<IDictionary<string, object>>
    {
        public bool Equals(IDictionary<string, object> x, IDictionary<string, object> y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            if (x.Count != y.Count)
                return false;
            return x.All(pair => y.ContainsKey(pair.Key) && Equals(pair.Value, y[pair.Key]));
        }

        public int GetHashCode(IDictionary<string, object> obj)
        {
            unchecked
            {
                int hash = 17;
                foreach (var pair in obj.OrderBy(kvp => kvp.Key))
                {
                    hash = hash * 31 + pair.Key.GetHashCode();
                    if (pair.Value != null)
                        hash = hash * 31 + pair.Value.GetHashCode();
                }
                return hash;
            }
        }
    }
}
