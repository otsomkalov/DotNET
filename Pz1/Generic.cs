using System;
using System.Collections.Generic;
using System.Linq;

namespace Pz1
{
    public static class Generic
    {
        public static void Demonstrate()
        {
            var anyInt = new Func<IEnumerable<int>, bool>(collection => collection.Any());
            var anyBool = new Func<IEnumerable<bool>, bool>(collection => collection.Any());

            var intCollection = Enumerable.Empty<int>();
            var boolCollection = new[] {true, false};

            Console.WriteLine(anyInt(intCollection));
            Console.WriteLine(anyBool(boolCollection));
        }
    }
}