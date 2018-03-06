using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WpfApp1.Properties;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            this.DataContext = _vm;
        }

        private MainViewModel _vm;
        public MainViewModel ViewModel
        {
            get { return _vm; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.SelDogName = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _vm.BlankDogList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _vm.ReloadDogList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _vm.SelDogName = "BlahBlah";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _vm.SelDogName = "Bowser";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("SelDogName: [{0}]", _vm.SelDogName));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel");
        }
    }
}
