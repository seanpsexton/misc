using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Dog : INPCBase
    {
        private static bool _dogOK;
        public static bool DogOK
        {
            get { return _dogOK; }
            set
            {
                if (value != _dogOK)
                    _dogOK = value;
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        public string DoubleName
        {
            get { return string.Format("{0} {0}", Name); }
        }

        private string _breed;
        public string Breed
        {
            get { return _breed; }
            set { SetField(ref _breed, value); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetField(ref _age, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (SetField(ref _isSelected, value))
                {
                    Trace.WriteLine(string.Format("Dog {0} selection changed to {1}", Name, _isSelected));
                    OnSelectionChanged(_isSelected);
                }
            }
        }

        public void SetSelected(bool isSelected)
        {
            // Set selection w/o firing event (since parent is invoking, we don't want parent notified that state changed
            SetField(ref _isSelected, isSelected, "IsSelected");
        }

        public event EventHandler<SelectionChangedEventArgs> SelectionChanged = delegate { };

        protected virtual void OnSelectionChanged(bool selected) 
        {
            SelectionChanged(this, new SelectionChangedEventArgs(selected));
        }

        public Dog(string name, int age, bool isSelected)
        {
            Name = name;
            Age = age;
            IsSelected = isSelected;
        }

        public Dog(string name, int age) : this(name, age, false) { }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Age);
        }
    }

    public class SelectionChangedEventArgs : EventArgs
    {
        public bool Selected { get; protected set; }
        public SelectionChangedEventArgs(bool selected)
        {
            Selected = selected;
        }
    }
}
