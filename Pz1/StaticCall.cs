using System;

namespace Pz1
{
    public static class StaticCall
    {
        public static void Demonstrate()
        {
            DESFunction encryptFunction = DES.DES.Encrypt;
            Console.WriteLine(encryptFunction.Invoke("qweasdzxc", "qweasdzx"));
        }

        private delegate string DESFunction(string text, string key);
    }
}