using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace HelloWorld
{
    public enum LoginPanel { FirstLast, Hobby, Done, Error, NONE };

    public class MainViewModel : INPCBase   //, IDropTarget
    {
        public MainViewModel()
        {
            DoSomethingCommand = new DelegateCommand(DoSomething, CanDoSomething);

            //DoSomethingCommand = new DelegateCommand(
            //    (obj) => MessageBox.Show($"Name is {LastName},{FirstName}"),                     // Execute
            //    (obj) => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName)     // CanExecute
            //    );

            LoadDogList();
        }

        public DelegateCommand DoSomethingCommand { get; private set; }

        private void DoSomething(object ignore)
        {
            MessageBox.Show($"Name is {LastName},{FirstName}");
        }

        private bool CanDoSomething(object ignore)
        {
            return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (SetField(ref _firstName, value))
                {
                    DoSomethingCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (SetField(ref _lastName, value))
                {
                    DoSomethingCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private List<Dog> _dogs;
        public List<Dog> Dogs
        {
            get { return _dogs; }
            private set { SetField(ref _dogs, value); }
        }

        private Dog _favDog;
        public Dog FavDog
        {
            get { return _favDog; }
            set { SetField(ref _favDog, value); }
        }

        private void LoadDogList()
        {
            Dogs = new List<Dog>()
            {
                new Dog("Bowser", 4, "Poodle"),
                new Dog("Fido", 5, "Hound"),
                new Dog("Bob", 15, "English Cocker Spaniel"),
                new Dog("Rover II", 10, "Fox Terrier"),
                new Dog("Rover", 1, "Fox Terrier")
            };
        }
    }
}