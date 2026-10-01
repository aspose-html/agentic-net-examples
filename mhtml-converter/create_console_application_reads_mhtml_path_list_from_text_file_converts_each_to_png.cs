// Create a console application that reads a list of MHTML paths from a text file and converts each to PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string listPath = "mhtml_paths.txt";

            if (!File.Exists(listPath))
            {
                // Create a sample MHTML file (simple HTML content) and list file for demonstration
                string sampleMhtml = "sample.mht";
                File.WriteAllText(sampleMhtml, "<html><body><h1>Sample MHTML</h1></body></html>");
                File.WriteAllLines(listPath, new[] { sampleMhtml });
            }

            foreach (string line in File.ReadAllLines(listPath))
            {
                string mhtmlPath = line.Trim();
                if (string.IsNullOrEmpty(mhtmlPath))
                    continue;

                if (!File.Exists(mhtmlPath))
                {
                    Console.WriteLine($"Input file not found: {mhtmlPath}");
                    continue;
                }

                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    string outputPath = Path.ChangeExtension(mhtmlPath, ".png");
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Converted '{mhtmlPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}