using System.Collections.Generic;
using System.Windows.Input;

namespace DragDropInList
{
    public class MainViewModel : INPCBase
    {
        public MainViewModel()
        {
            InitializeCommands();
            Dogs = new List<Dog>()
            {
                new Dog("Bowser", 12),
            }
        }

        private List<Dog> _dogs;
        public List<Dog> Dogs
        {
            get { return _dogs; }
            private set { SetField(ref _dogs, value); }
        }

        public ICommand PopDialogCommand { get; set; }

        private void InitializeCommands()
        {
            PopDialogCommand = new DelegateCommand(
                () =>
                {
                },
                () => true);
        }
    }
}
