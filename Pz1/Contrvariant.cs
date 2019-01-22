using System;
using System.Collections.Generic;

namespace Pz1
{
    internal static class Contrvariant
    {
        public static void Demonstrate()
        {
            GetStringRepresentation<IEnumerable<int>> collectionStringRepresentation = GetCollectionStringRepresentation;
            GetStringRepresentation<List<int>> listStringRepresentation = GetListStringRepresentation;

            listStringRepresentation = collectionStringRepresentation;

            var list = new List<int>();

            listStringRepresentation(list);
        }

        private static void GetListStringRepresentation(List<int> collection)
        {
            Console.WriteLine(collection.ToString());
        }

        private static void GetCollectionStringRepresentation(IEnumerable<int> collection)
        {
            Console.WriteLine(collection.ToString());
        }

        private delegate void GetStringRepresentation<in T>(T collection);
    }
}