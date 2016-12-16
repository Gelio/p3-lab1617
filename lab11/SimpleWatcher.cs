using System;

namespace Lab11a
{
    class SimpleWatcher : IWatcher
    {
        public void Watch(IChangeNotifing ChangeNotifier)
        {
            if (ChangeNotifier == null)
                return;
            ChangeNotifier.Changed += _handleEvent;
        }

        public void StopWatching(IChangeNotifing ChangeNotifier)
        {
            if (ChangeNotifier == null)
                return;
            ChangeNotifier.Changed -= _handleEvent;
        }

        public void _handleEvent(object sender, NotifyEventArgs e)
        {
            Console.WriteLine("Object changed");
        }
    }
}
