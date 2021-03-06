﻿using System;

namespace Lab11a
{
    class Matryoshka : IChangeNotifing
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private string _theme;
        public string Theme
        {
            get { return _theme; }
            set {
                if (Changed != null)
                    Changed(this, new NotifyEventArgs("Theme"));
                _theme = value;
            }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set {
                if (Changed != null)
                    Changed(this, new NotifyEventArgs("Color"));
                _color = value;
            }
        }

        private Matryoshka _innerDoll;
        public Matryoshka InnerDoll
        {
            get { return _innerDoll; }
            set {
                if (_innerDoll != null)
                    _innerDoll.Changed -= _bubbleEvent;

                if (Changed != null)
                    Changed(this, new NotifyEventArgs("InnerDoll"));
                _innerDoll = value;

                if (_innerDoll != null)
                    _innerDoll.Changed += _bubbleEvent;
            }
        }

        public event EventHandler<NotifyEventArgs> Changed;

        public Matryoshka(string name)
        {
            _name = name;
        }

        private void _bubbleEvent(object sender, NotifyEventArgs e)
        {
            if (Changed == null)
                return;

            Changed(this, new NotifyEventArgs("InnerDoll." + e.PropertyName));
        }
    }
}
