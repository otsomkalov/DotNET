using System;

namespace Pz1
{
    public static class StaticCall
    {
        public static void Demonstrate()
        {
            DESFunction function = DES.DES.Encrypt;
            Console.WriteLine(function.Invoke("qweasdzxc", "qweasdzx"));
        }

        private delegate string DESFunction(string text, string key);
    }
}