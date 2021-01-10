using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinFormsHosting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = sender as System.Windows.Forms.Button;

            b.Top = 20;
            b.Left = 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.host1.Visibility = Visibility.Hidden;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.host1.Visibility = Visibility.Collapsed;
        }
    }
}
