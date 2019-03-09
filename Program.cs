using System.Collections.Generic;
using System.IO;

/******************************************************************************************************/

namespace MP3Listing
{
    class Program
    {
        static void Main(string[] args)
        {
            // List all files in all subdirectories
            string currentDir = Directory.GetCurrentDirectory();
            int currentDirLen = currentDir.Length;
            string[] allFiles = Directory.GetFiles(currentDir, "*.*", SearchOption.AllDirectories);
            List<string> finalFiles = new List<string>();

            // Remove unwanted entries
            string[] unwantedNames = { "MP3Listing.exe", "mp3.txt" };
            foreach (string file in allFiles)
            {
                // +1 to remove initial "/"
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

            // Save the list to a txt file
            TextWriter tw = new StreamWriter("mp3.txt");
            foreach (string finalFile in finalFiles)
                tw.WriteLine(finalFile);
            tw.Close();
        }
    }
}

/******************************************************************************************************/
