using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Dog myDog;

        public Window2()
        {
            //var be1 = this.GetBindingExpression(MinSizeToContentProperty);
            InitializeComponent();
            //var be2 = this.GetBindingExpression(MinSizeToContentProperty);
            //DataContext = new TestViewModel(); 
            //var be3 = this.GetBindingExpression(MinSizeToContentProperty);

            //this.LayoutUpdated += Window2_LayoutUpdated;
            //this.Loaded += (sender, args) =>
            //{
            //    var be = this.GetBindingExpression(MinSizeToContentProperty);
            //};
            myDog = new Dog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            win.Show();
        }

        //private void Window2_LayoutUpdated(object sender, EventArgs e)
        //{
        //    var be = this.GetBindingExpression(MinSizeToContentProperty);
        //}
    }
}
