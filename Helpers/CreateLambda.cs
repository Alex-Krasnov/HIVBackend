using System.Linq.Expressions;

namespace HIVBackend.Helpers
{
    public class CreateLambda<T>
    {
        public Func<T, IDictionary<string, object>> CreateLambdaSelect(List<string> fields)
        {
            var parameter = Expression.Parameter(typeof(T), "e");

            var dictionaryElements = new List<ElementInit>();
            foreach (var columnName in fields)
            {
                dictionaryElements.Add(
                    Expression.ElementInit(
                        typeof(Dictionary<string, object>).GetMethod("Add"),
                        Expression.Constant(columnName),
                        Expression.Convert(Expression.Property(parameter, columnName),
                        typeof(object))
                    )
                );
            }

            var dictionaryInit = Expression.ListInit(
            Expression.New(typeof(Dictionary<string, object>)),
            dictionaryElements);

            var lambdaSelect = Expression.Lambda<Func<T, IDictionary<string, object>>>(dictionaryInit, parameter);// e => new { e. ,...}

            return lambdaSelect.Compile();
        }
    }
}
