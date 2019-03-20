using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SomeViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new SomeViewModel();
            this.DataContext = ViewModel;
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            // https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp
            string password = "MonkeysFlyStovetopGravy";

            // For additional security Pin the password of your files
            //GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Encrypt the file
            EncryptDecrypt.FileEncrypt2(@"..\..\Words.txt");

            // To increase the security of the encryption, delete the given password from the memory !
            //ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            //gch.Free();
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string password = "MonkeysFlyStovetopGravy";

            // For additional security Pin the password of your files
            //GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Decrypt the file - external file
            //var wordlist = EncryptDecrypt.FileDecrypt2(File.ReadAllBytes(@"..\..\Words.dat"));

            // Decrypt the file - bytes in resource
            var wordlist = EncryptDecrypt.FileDecrypt2(WPFApp1.Properties.Resources.Words);

            // To increase the security of the decryption, delete the used password from the memory !
            //ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            //gch.Free();
        }
    }
}
