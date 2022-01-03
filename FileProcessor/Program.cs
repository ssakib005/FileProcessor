using System;
using System.IO;

namespace FileProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start(@"your file path");
        }
        public static void Start(string path)
        {
            if (File.Exists(path))
            {
                //File Path
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                // Directory Path
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
        }
        static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }
    }
}
