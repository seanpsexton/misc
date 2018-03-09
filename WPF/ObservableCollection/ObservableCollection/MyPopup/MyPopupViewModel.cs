using System.Collections.ObjectModel;
using TestApp.Core;
using TestApp.Model;

namespace TestApp.Popup
{
    public class MyPopupViewModel : INPCBase
    {
        public MyPopupViewModel()
        {
            LoadDogList();
            InitializeCommands();
        }

        private ObservableCollection<Dog> _dogs;
        public ObservableCollection<Dog> Dogs
        {
            get { return _dogs; }
            set { SetField(ref _dogs, value); }
        }

        private void LoadDogList()
        {
            Dogs = new ObservableCollection<Dog>()
            {
                new Dog("Fido", 5),
                new Dog("Bowser", 12),
                new Dog("Rover", 4)
            };
        }

        private void InitializeCommands()
        {
        }
    }
}
