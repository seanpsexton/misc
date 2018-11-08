using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

namespace DepPropAttributeExample
{
    /// <summary>
    /// DepProp attributes indicate properties in Dog that the associated property depends on.
    /// </summary>
    public class MainViewModel : INPCBase   
    {
        // Keys in dictionary are bus object properties, value in dictionary is list of ViewModel
        // props that depend on that property. Built at runtime from [DepProp] attributes.
        private Dictionary<string, List<string>> _depProps = new Dictionary<string, List<string>>();

        public MainViewModel()
        {
            // Build structure of dependent properties--populating it based on the DepProp attributes
            _depProps = DepPropAttribute.MapDependentProperties(typeof(MainViewModel));
        }

        [DepProp("Name")]
        public string DerivedName
        {
            get { return _theDog.Name + "-y"; }
        }

        [DepProp("Name")]
        [DepProp("Age")]
        public string NameAndAge
        {
            get { return $"{_theDog.Name} ({_theDog.Age})"; }
        }

        private Dog _theDog;
        public Dog TheDog
        {
            get { return _theDog; }
            protected set
            {
                if (_theDog == value)
                    return;

                // Detach from old
                if (_theDog != null)
                    _theDog.PropertyChanged -= BusObjPropertyChanged;

                SetField(ref _theDog, value);

                // Attach to new
                if (_theDog != null)
                {
                    _theDog.PropertyChanged += BusObjPropertyChanged;
                    FireAllDepPropNotify();
                }
            }
        }

        /// <summary>
        /// Fire dependent prop notify
        /// </summary>
        private void BusObjPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_depProps != null)
            {
                if (string.IsNullOrWhiteSpace(e.PropertyName))
                {
                    FireAllDepPropNotify();
                }
                else if (_depProps.ContainsKey(e.PropertyName))
                {
                    FirePropsInList(_depProps[e.PropertyName]);
                }
                CommandManager.InvalidateRequerySuggested();
            }
        }

        /// <summary>
        /// Fire prop changed notification on all dependent properties
        /// </summary>
        private void FireAllDepPropNotify()
        {
            foreach (var kvp in _depProps ?? Enumerable.Empty<KeyValuePair<string, List<string>>>())
            {
                FirePropsInList(kvp.Value);
            }
        }

        private void FirePropsInList(List<string> proplist)
        {
            foreach (var prop in proplist ?? Enumerable.Empty<string>())
            {
                RaisePropChanged(prop);
            }
        }
    }
}