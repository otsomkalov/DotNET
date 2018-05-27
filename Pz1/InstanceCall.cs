using System;

namespace Pz1
{
    public static class InstanceCall
    {
        public static void Demonstrate()
        {
            const int number = 42;
            GetStringRepresentation stringRepresentation = number.ToString;
            Console.WriteLine(stringRepresentation());
        }

        private delegate string GetStringRepresentation();
    }
}