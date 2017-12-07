using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArt
{
    class Program
    {
        /// <summary>
        /// Usage:
        ///   Arg 1 - Full path to bitmap file (e.g. JPG, PNG)
        ///   Arg 2 - Width of target image, in # characters (e.g. 120)
        ///   Output: File with same name as input file but .txt extension
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage:");
                    Console.WriteLine("  AscArt filename output-width");
                }
                else
                {
                    string inputFile = args[0];
                    int outputWidth = int.Parse(args[1]);

                    FileInfo fi = new FileInfo(inputFile);
                    if (!fi.Exists)
                        throw new Exception(string.Format("File {0} not found", inputFile));
                    string outputFile = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(inputFile) + ".txt");

                    Bitmap bmInput = new Bitmap(inputFile);

                    if (outputWidth > bmInput.Width)
                        throw new Exception("Output width must be <= pixel width of image");

                    // Generate the ASCII art
                    AscArt.GenerateAsciiArt(bmInput, outputFile, outputWidth);
                }
            }
            catch (Exception xx)
            {
                Console.WriteLine(string.Format("Fatal exception: {0}", xx));
            }
        }
    }
}
