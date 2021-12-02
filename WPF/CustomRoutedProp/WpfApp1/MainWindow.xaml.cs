using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestViewModel vm;

        public MainWindow()
        {
            //var x = new MyDataGrid();
            InitializeComponent();
            vm = new TestViewModel();
            DataContext = vm;
        }

        private void btnTestClick(object sender, RoutedEventArgs e)
        {
            var win2 = new Window2();
            win2.Show();
        }

        private void btnGCClick(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
