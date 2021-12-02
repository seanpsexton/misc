using System;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public enum Choices
    {
        First = 0,
        Second = 1,
        Third = 2
    };

    public class TestViewModel : ViewModelBase
    {
        public TestViewModel()
        {
            int agegen = 3;

            dogs = new ObservableCollection<Dog>()
            {
                new Dog("Bowser", 5),
                new Dog("Fred", agegen++),
                new Dog("_Betty", agegen++),
                new Dog("_Wilma", agegen++),
                new Dog("Barney", agegen++),
                new Dog("Rex", agegen++),
                new Dog("Leon", agegen++),
                new Dog("Decker", agegen++),
                new Dog("Jessica", agegen++),
                new Dog("Roger", agegen++)
            };

            ColGroup = ColumnGroup.BColumns;
        }

        private ColumnGroup colGroup;
        public ColumnGroup ColGroup
        {
            get => colGroup;
            set
            {
                if (SetField(ref colGroup, value))
                {
                    OnPropertyChanged(nameof(ColGroupDisplay));
                }
            }
        }

        public string ColGroupDisplay
        {
            get => colGroup.ToString();
        }

        private ObservableCollection<Dog> dogs;
        public ObservableCollection<Dog> Dogs
        {
            get { return dogs; }
        }
    }
}
