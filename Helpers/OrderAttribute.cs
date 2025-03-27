namespace HIVBackend.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OrderAttribute : Attribute
    {
        public double Order { get; } = double.MaxValue;

        public OrderAttribute(double order)
        {
            Order = order;
        }
    }
}
