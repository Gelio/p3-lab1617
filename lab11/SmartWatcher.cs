using System;

namespace Lab11a
{
    class SmartWatcher : IWatcher
    {
        public void Watch(IChangeNotifing changeNotifier)
        {
            if (changeNotifier == null)
                return;

            changeNotifier.Changed += _handleEvent;
        }

        public void StopWatching(IChangeNotifing changeNotifier)
        {
            if (changeNotifier == null)
                return;

            changeNotifier.Changed -= _handleEvent;
        }

        public void _handleEvent(object sender, NotifyEventArgs e)
        {
            if (!(sender is IChangeNotifing))
                return;

            IChangeNotifing changeNotifier = sender as IChangeNotifing;
            Console.WriteLine("Object {0} changed property: {1}",
                changeNotifier.Name, e.PropertyName);
        }
    }
}
