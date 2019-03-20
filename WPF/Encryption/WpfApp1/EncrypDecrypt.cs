using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class EncryptDecrypt
    {
        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns></returns>
        private static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        /// <summary>
        /// Encrypts a file from its path and a plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="password"></param>
        public static void FileEncrypt(string inputFile, string password)
        {
            //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files

            //generate random salt
            byte[] salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
            //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            DumpBytes(AES.Key);
            DumpBytes(AES.IV);

            //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        public static void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);

            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// Encrypts a file from its path and a plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="password"></param>
        public static void FileEncrypt2(string inputFile)
        {
            //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files

            //create output file name
            FileInfo fi = new FileInfo(inputFile);
            var cryptFilename = fi.FullName.Replace(fi.Extension, ".dat");
            FileStream fsCrypt = new FileStream(cryptFilename, FileMode.Create);

            //convert password string to byte arrray
            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            AES.Key = new byte[] { 0x22, 0x6b, 0x7f, 0x85, 0x48, 0x5c, 0x01, 0xf4, 0xc7, 0x37, 0xae, 0xb9, 0x0e, 0x6a, 0xbb, 0x55, 0x13, 0xf6, 0x35, 0xd3, 0x8a, 0xf8, 0xb3, 0x07, 0xe2, 0xc6, 0x2a, 0x79, 0xf1, 0x36, 0xdd, 0xf0 };
            AES.IV = new byte[] { 0xa1, 0xc3, 0x41, 0xd6, 0xc4, 0xbe, 0xf7, 0x52, 0xdc, 0x53, 0x60, 0x65, 0x36, 0xe0, 0xee, 0x10 };

            //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// Decrypt byte array into plaintext list of words
        /// </summary>
        public static string[] FileDecrypt2(byte[] inputBytes)
        {
            MemoryStream msCrypt = new MemoryStream(inputBytes);

            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Key = new byte[] { 0x22, 0x6b, 0x7f, 0x85, 0x48, 0x5c, 0x01, 0xf4, 0xc7, 0x37, 0xae, 0xb9, 0x0e, 0x6a, 0xbb, 0x55, 0x13, 0xf6, 0x35, 0xd3, 0x8a, 0xf8, 0xb3, 0x07, 0xe2, 0xc6, 0x2a, 0x79, 0xf1, 0x36, 0xdd, 0xf0 };
            aes.IV = new byte[] { 0xa1, 0xc3, 0x41, 0xd6, 0xc4, 0xbe, 0xf7, 0x52, 0xdc, 0x53, 0x60, 0x65, 0x36, 0xe0, 0xee, 0x10 };
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(msCrypt, aes.CreateDecryptor(), CryptoStreamMode.Read);
            MemoryStream msOut = new MemoryStream();

            int read;
            const int MEGABYTE = 1048576;
            byte[] buffer = new byte[MEGABYTE];

            while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
            {
                msOut.Write(buffer, 0, read);
            }
            msOut.Position = 0;

            string words;
            using (var reader = new StreamReader(msOut))
            {
                words = reader.ReadToEnd();
            }

            cs.Close();
            msOut.Close();
            msCrypt.Close();

            return words.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        private static void DumpBytes(byte[] bytes)
        {
            Trace.WriteLine("==============");
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("0x{0:x2}, ", b);
            }
            Trace.WriteLine(sb.ToString());
        }
    }
}
