using System.Collections.Generic;
using System.IO;

namespace InefficientCode
{
    public class Disk
    {
        public Dictionary<string, string> ReadAllFilesInDirectory(string directory)
        {
            Dictionary<string, string> fileNameAndContents = new Dictionary<string, string>();

            foreach (string filename in Directory.EnumerateFiles(directory))
            {
                string contents = File.ReadAllText(filename);

                fileNameAndContents.Add(filename, contents);
            }

            return fileNameAndContents;
        }
    }
}
