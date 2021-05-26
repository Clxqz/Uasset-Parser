using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UassetParser
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "Uasset Parser | Made By Clxqz#0001";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select A Uasset File: ");
            Console.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                grabAssetStrings(ofd.FileName);
                Console.ReadLine();
            }
 
        }
        public static void grabAssetStrings(string path)
        {
            string assetStrings;
            string assetData = "/Game/Athena/Heroes/Meshes/Bodies/";
            if(path.Contains(".uasset"))
            {
                StreamReader sr = new StreamReader(path);
                while ((assetStrings = sr.ReadLine()) != null)
                {

                    if (assetStrings.Contains(assetData))
                    {  
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        int offset = assetStrings.IndexOf("/", StringComparison.Ordinal);
                        var substring = assetStrings.Substring(offset);
                        Console.WriteLine($"\n{substring.Replace(" ", "")}");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.Write("Do you want to save asset text into a txt file (y/n)?: ");
                        string saveText = Console.ReadLine().ToLower();
                        if(saveText == "y")
                        {
                            var parsedAsset = Environment.CurrentDirectory + "/parsedUassetStrings.txt";
                            using (StreamWriter sw = new StreamWriter(parsedAsset))
                            {
                                sw.WriteLine($"\n{substring.Replace(" ", "")}");
                                sw.Close();
                                string notepadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "notepad.exe");
                                Process.Start(notepadPath, parsedAsset);
                            }
                             
                        }
                        if(saveText == "n")
                        {
                            Console.WriteLine("Exiting Program Now....");
                            Thread.Sleep(1000);
                            Environment.Exit(0);

                        }
                        
                    }
                    else if (!assetStrings.Contains(assetData))
                    {
                        try
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            int offset = assetStrings.IndexOf("/", StringComparison.Ordinal);
                            var substring = assetStrings.Substring(offset);
                            Console.WriteLine($"\n{substring.Replace(" ", "")}");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("Do you want to save asset text into a txt file (y/n)?: ");
                            string saveText = Console.ReadLine().ToLower();
                            if (saveText == "y")
                            {
                                var parsedAsset = Environment.CurrentDirectory + "/parsedUassetStrings.txt";
                                using (StreamWriter sw = new StreamWriter(parsedAsset))
                                {
                                    sw.WriteLine($"\n{substring.Replace(" ", "")}");
                                    sw.Close();
                                    string notepadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "notepad.exe");
                                    Process.Start(notepadPath, parsedAsset);
                                    Console.WriteLine("Exiting Program Now....");
                                    Thread.Sleep(1000);
                                    Environment.Exit(0);
                                }

                            }
                            if (saveText == "n")
                            {
                                Console.WriteLine("Exiting Program Now....");
                                Thread.Sleep(1000);
                                Environment.Exit(0);

                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            else if(!path.Contains(".uasset"))
            {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The File Path, Is Not Uasset...");
                Application.Restart();
                Environment.Exit(0);
            }

        }
    }
}
