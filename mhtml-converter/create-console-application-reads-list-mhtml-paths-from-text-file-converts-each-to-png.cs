// Create a console application that reads a list of MHTML paths from a text file and converts each to PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string listFilePath = "mhtml_list.txt";

            if (!File.Exists(listFilePath))
            {
                // Create a sample list file and a minimal MHTML file for demonstration
                File.WriteAllText(listFilePath, "sample.mhtml");
                File.WriteAllText("sample.mhtml", "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            string[] mhtmlPaths = File.ReadAllLines(listFilePath);
            foreach (string line in mhtmlPaths)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string inputPath = line.Trim();
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Input file not found: {inputPath}");
                    continue;
                }

                using (FileStream stream = File.OpenRead(inputPath))
                {
                    string outputPath = Path.ChangeExtension(inputPath, ".png");
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}