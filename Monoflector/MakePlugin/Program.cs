using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;

namespace MakePlugin
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: MakePlugin [Input] [Output]");
                Console.WriteLine("  Input: The directory containing the files.");
                Console.WriteLine("  Output: The full filename for the output file.");
                return -1;
            }
            var input = Path.GetFullPath(args[0]);
            var output = Path.GetFullPath(args[1]);

            if (!input.EndsWith(Path.DirectorySeparatorChar.ToString()) &&
                !input.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
            {
                input += Path.DirectorySeparatorChar;
            }

            using (var file = new ZipFile())
            {
                file.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                foreach (var componentFile in Directory.GetFiles(input, "*", SearchOption.AllDirectories))
                {
                    var relativePath = Path.GetDirectoryName(componentFile);
                    if (!relativePath.EndsWith(Path.DirectorySeparatorChar.ToString()) &&
                        !relativePath.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
                    {
                        relativePath += Path.DirectorySeparatorChar;
                    }

                    relativePath = relativePath.Substring(input.Length);
                    relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, '\\');
                    relativePath = relativePath.Replace(Path.DirectorySeparatorChar, '\\');
                    file.AddFile(componentFile, relativePath);
                }
                File.Delete(output);
                file.Save(output);
            }

            return 0;
        }
    }
}
