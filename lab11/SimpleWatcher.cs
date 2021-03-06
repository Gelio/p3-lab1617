﻿using System;

namespace Lab11a
{
    class SimpleWatcher : IWatcher
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
            Console.WriteLine("Object changed");
        }
    }
}
