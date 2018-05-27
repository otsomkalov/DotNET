using System;

namespace Pz1
{
    internal class Program
    {
        public static void Main()
        {
            Covariant.Demonstrate();
            Contrvariant.Demonstrate();
            StaticCall.Demonstrate();
            InstanceCall.Demonstrate();
            DelegatesChain.Demonstrate();
            Generic.Demonstrate();

            var example = new EventExample();
            example.OnPropertyChange += value => Console.WriteLine($"Property changed to {value}!");
            example.Property = 10;
            example.Property = 20;
        }
    }
}