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
                // Create a sample list file with a placeholder entry
                File.WriteAllText(listFilePath, "sample.mht");
                Console.WriteLine($"Created sample list file at '{listFilePath}'. Add MHTML file paths to this file.");
                return;
            }

            string[] mhtmlPaths = File.ReadAllLines(listFilePath);

            foreach (string mhtmlPath in mhtmlPaths)
            {
                if (string.IsNullOrWhiteSpace(mhtmlPath))
                    continue;

                string trimmedPath = mhtmlPath.Trim();

                if (!File.Exists(trimmedPath))
                {
                    Console.WriteLine($"MHTML file not found: '{trimmedPath}'. Skipping.");
                    continue;
                }

                string outputPath = Path.ChangeExtension(trimmedPath, ".png");

                using (FileStream stream = File.OpenRead(trimmedPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine($"Converted '{trimmedPath}' to PNG at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}