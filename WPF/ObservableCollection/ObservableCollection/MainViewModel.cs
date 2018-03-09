using System.Windows;
using System.Windows.Input;
using TestApp.Core;
using TestApp.Popup;

namespace TestApp
{
    public class MainViewModel : INPCBase
    {
        public MainViewModel()
        {
            InitializeCommands();
        }

        public ICommand PopDialogCommand { get; set; }

        private void InitializeCommands()
        {
            PopDialogCommand = new DelegateCommand(
                () =>
                {
                    var dlg = new MyPopup();
                    dlg.ShowDialog();
                },
                () => true);
        }
    }
}
