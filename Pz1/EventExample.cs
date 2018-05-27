using System;

namespace Pz1
{
    public class EventExample
    {
        public int Property
        {
            set => OnPropertyChange?.Invoke(value);
        }

        public event Action<int> OnPropertyChange;
    }
}