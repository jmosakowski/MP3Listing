using System.Collections.Generic;
using System.IO;

/******************************************************************************************************/

namespace MP3Listing
{
    class Program
    {
        static void Main(string[] args)
        {
            // List all files in a given directory and all its subdirectories
            string currentDir = Directory.GetCurrentDirectory();
            int currentDirLen = currentDir.Length;
            string[] allFiles = Directory.GetFiles(currentDir, "*.*", SearchOption.AllDirectories);
            List<string> finalFiles = new List<string>();

            // Remove files with unwanted names
            string[] unwantedNames = { "MP3Listing.exe", "mp3.txt" };
            foreach (string file in allFiles)
            {
                // +1 in file.Remove to remove initial "/"
                string fileShort = file.Remove(0, currentDirLen + 1);
                bool containsForbidden = false;
                foreach (string unwantedName in unwantedNames)
                    if (fileShort == unwantedName)
                    {
                        containsForbidden = true;
                        break;
                    }
                if (!containsForbidden)
                    finalFiles.Add(fileShort);
            }

            // Save the MP3 list to a txt file
            TextWriter tw = new StreamWriter("mp3.txt");
            foreach (string finalFile in finalFiles)
                tw.WriteLine(finalFile);
            tw.Close();
        }
    }
}

/******************************************************************************************************/
