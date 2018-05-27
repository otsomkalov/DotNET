using System;
using System.Collections.Generic;

namespace Pz1
{
    internal static class Contrvariant
    {
        public static void Demonstrate()
        {
            GetStringRepresentation<IEnumerable<int>> ienumerableStringRepresentation = IenumerableStringRepresentation;
            GetStringRepresentation<List<int>> listStringRepresentation = ListStringRepresentation;

            listStringRepresentation = ienumerableStringRepresentation;

            var list = new List<int>();

            listStringRepresentation(list);
        }

        private static void ListStringRepresentation(List<int> collection)
        {
            Console.WriteLine(collection.ToString());
        }

        private static void IenumerableStringRepresentation(IEnumerable<int> collection)
        {
            Console.WriteLine(collection.ToString());
        }

        private delegate void GetStringRepresentation<in T>(T collection);
    }
}