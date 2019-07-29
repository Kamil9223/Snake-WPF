using System;
using System.Reflection;
using System.Windows.Threading;

namespace SnakeWPF.Managers
{
    class Timer
    {
        public DispatcherTimer dispatcherTimer;

        public Timer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.15);
        }

        public void RemoveHandlers()
        {
            var eventField = dispatcherTimer.GetType().GetField("Tick",
                    BindingFlags.NonPublic | BindingFlags.Instance);
            var eventDelegate = (Delegate)eventField.GetValue(dispatcherTimer);
            if (eventDelegate != null)
            {
                var invocatationList = eventDelegate.GetInvocationList();

                foreach (var handler in invocatationList)
                    dispatcherTimer.Tick -= ((EventHandler)handler);
            }            
        }
    }
}
