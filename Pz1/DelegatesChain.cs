using System;

namespace Pz1
{
    public static class DelegatesChain
    {
        public static void Demonstrate()
        {
            var action1 = new Action(() => Console.WriteLine("Action 1"));
            var action2 = new Action(() => Console.WriteLine("Action 2"));
            var action3 = new Action(() => Console.WriteLine("Action 3"));

            var all = action1 + action2 + action3 + Console.WriteLine;
            all();

            var firstAndThird = all - action2;
            firstAndThird();

            var second = all - (action1 + action3);
            second();

            foreach (var del in all.GetInvocationList())
            {
                var action = del as Action;
                action?.Invoke();
            }
        }
    }
}