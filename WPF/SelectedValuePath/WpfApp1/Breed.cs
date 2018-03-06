using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Breed : INPCBase
    {
        public Breed()
        {
            _dogs = new ObservableCollection<Dog>();
            Dogs = new ReadOnlyObservableCollection<Dog>(_dogs);
        }

        /// <summary>
        /// Fires when child selection changes after initial load. Note that parent selection can be 
        /// assumed to be false or null (since we prohibit changing child selection when parent is 
        /// selected).
        /// </summary>
        private void ChildSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dog = sender as Dog;

            IsSelected = Dogs.Any(d => d.IsSelected) ? (bool?)null : false;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        private ObservableCollection<Dog> _dogs;
        public ReadOnlyObservableCollection<Dog> Dogs { get; set; }

        private bool? _isSelected;
        public bool? IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (SetField(ref _isSelected, value))
                {
                    // If being set to true or false, auto-select all children
                    if (_isSelected.HasValue)
                    {
                        foreach (var d in _dogs)
                        {
                            d.SetSelected(_isSelected.Value);
                        }
                    }
                }
            }
        }

        public Breed(string name, bool? isSelected = false) : this()
        {
            Name = name;
            IsSelected = isSelected;
        }

        public void AddDog(string name, int age, bool isSelected = false)
        {
            // Child cannot select if parent is selected
            bool childSelected = isSelected || (IsSelected == true);

            var newdog = new Dog(name, age, childSelected);
            newdog.SelectionChanged += ChildSelectionChanged;

            _dogs.Add(newdog);

            if ((IsSelected == false) && Dogs.Any(d => d.IsSelected))
                IsSelected = null;
        }

        public override string ToString()
        {
            return string.Format("Breed: {0}", Name);
        }
    }
}
