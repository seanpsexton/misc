using System.Collections.ObjectModel;
using System.Windows.Input;
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

        public ICommand RegenListCommand { get; set; }

        private void LoadDogList()
        {
            Dogs = new ObservableCollection<Dog>()
            {
                new Dog("Fido", 5),
                new Dog("Bowser", 12),
                new Dog("Rover", 4),
                new Dog("Agustin", 1),
                new Dog("Rodolfo", 2),
                new Dog("Tobias", 3),
                new Dog("Erick", 4),
                new Dog("Elbert", 5),
                new Dog("Derek", 6),
                new Dog("Clair", 7),
                new Dog("Patricia", 8),
                new Dog("Ignacio", 9),
                new Dog("Deon", 10),
                new Dog("Percy", 11),
                new Dog("Val", 12),
                new Dog("Clay", 13),
                new Dog("Emanuel", 14),
                new Dog("Royal", 15),
                new Dog("Jess", 16),
                new Dog("Long", 17),
                new Dog("Rob", 18),
                new Dog("Malcolm", 19),
                new Dog("Randal", 20),
                new Dog("Julius", 21),
                new Dog("Manual", 22),
                new Dog("Keneth", 23),
                new Dog("Johnathon", 24),
                new Dog("Sal", 25),
                new Dog("Josh", 26),
                new Dog("Dalton", 27),
                new Dog("Rusty", 28),
                new Dog("Merrill", 29),
                new Dog("Earle", 30),
                new Dog("Von", 31),
                new Dog("Enoch", 32),
                new Dog("Josiah", 33),
                new Dog("Amos", 34)
            };
        }

        private void InitializeCommands()
        {
            RegenListCommand = new DelegateCommand(
                () => LoadDogList(),
                () => true);
        }
    }
}
