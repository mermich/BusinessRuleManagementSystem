using System.Collections.Generic;
using System.Linq;

namespace TestsCreator
{
    public class Class1
    {
        public void plop() { }
    }

    public static class Extentions
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            IEnumerable<IEnumerable<T>> result = emptyProduct;
            foreach (IEnumerable<T> sequence in sequences)
            {
                result = from accseq in result from item in sequence select accseq.Concat(new[] { item });
            }
            return result;
        }
    }
}
