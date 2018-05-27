using System;
using System.Collections.Generic;
using System.Linq;

namespace Pz1
{
    internal static class Covariant
    {
        public static void Demonstrate()
        {
            GetEmptyCollection<IEnumerable<int>> ienumerableCollection = GetEmptyIenumerableCollection;
            GetEmptyCollection<List<int>> listCollection = GetEmptyListCollection;

            ienumerableCollection = listCollection;

            var collection = ienumerableCollection();

            Console.WriteLine(collection);
        }

        private static IEnumerable<int> GetEmptyIenumerableCollection()
        {
            return Enumerable.Empty<int>();
        }

        private static List<int> GetEmptyListCollection()
        {
            return new List<int>();
        }

        private delegate T GetEmptyCollection<out T>();
    }
}