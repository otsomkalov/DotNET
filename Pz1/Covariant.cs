using System;
using System.Collections.Generic;
using System.Linq;

namespace Pz1
{
    internal static class Covariant
    {
        public static void Demonstrate()
        {
            GetEmptyCollection<IEnumerable<int>> ienumerableCollection = GetEmptyIEnumerable;
            GetEmptyCollection<List<int>> listCollection = GetEmptyList;

            ienumerableCollection = listCollection;

            var collection = ienumerableCollection();

            Console.WriteLine(collection);
        }

        private static IEnumerable<int> GetEmptyIEnumerable()
        {
            return Enumerable.Empty<int>();
        }

        private static List<int> GetEmptyList()
        {
            return new List<int>();
        }

        private delegate T GetEmptyCollection<out T>();
    }
}