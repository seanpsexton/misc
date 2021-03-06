﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class INPCBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propname = null)
        {
            // Don't set field or fire event if property hasn't changed
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            RaisePropChanged(propname);

            return true;
        }

        protected void RaisePropChanged(string propname)
        {
            // Note: We don't check event for null because we initialize with empty delegate
            if (!string.IsNullOrEmpty(propname))
            {
                if (Application.Current == null || Application.Current.Dispatcher.CheckAccess())
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propname));
                }
                else
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => RaisePropChanged(propname)));
                }
            }
        }
    }
}
