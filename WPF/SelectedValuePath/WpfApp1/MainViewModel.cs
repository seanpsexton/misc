using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainViewModel : INPCBase
    {
        public MainViewModel()
        {
            LoadDogList();
        }

        private void LoadDogList()
        {
            Dogs = new List<Dog>()
            {
                new Dog("Fido", 5),
                new Dog("Bowser", 12),
                new Dog("Rover", 4)
            };
        }

        private List<Dog> _dogs;
        public List<Dog> Dogs
        {
            get { return _dogs; }
            set { SetField(ref _dogs, value); }
        }

        private string _selDogName;
        public string SelDogName
        {
            get { return _selDogName; }
            set { SetField(ref _selDogName, value); }
        }

        public void BlankDogList()
        {
            Dogs = null;
        }

        public void ReloadDogList()
        {
            LoadDogList();
        }
    }
}
