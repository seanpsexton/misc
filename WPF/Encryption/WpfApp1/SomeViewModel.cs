using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfApp1
{
    public class SomeViewModel : INotifyPropertyChanged
    {
        public SomeViewModel()
        {
        }


        protected bool SetProp<T>(ref T backingField, T value, [CallerMemberName] string propName = null)
        {
            bool valueChanged = false;

            // Can't use equality operator on generic types
            if (!EqualityComparer<T>.Default.Equals(backingField, value))
            {
                backingField = value;
                RaisePropertyChanged(propName);
                valueChanged = true;
            }

            return valueChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propname)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}
