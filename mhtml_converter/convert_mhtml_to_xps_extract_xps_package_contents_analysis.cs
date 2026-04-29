// Write code to convert MHTML to XPS and then extract the XPS package contents for analysis.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string inputMhtmlPath = "input.mhtml";
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "output.xps");

            // Convert MHTML to XPS
            using (FileStream stream = File.OpenRead(inputMhtmlPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            // Extract XPS package contents
            using (ZipArchive archive = ZipFile.OpenRead(outputPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string destinationPath = Path.Combine(outputDirectory, entry.FullName);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    entry.ExtractToFile(destinationPath, true);
                }
            }

            Console.WriteLine("Conversion and extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}