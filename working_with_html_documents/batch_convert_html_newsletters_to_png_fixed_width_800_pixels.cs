// Batch convert HTML newsletters, converting each to PNG with a fixed width of 800 pixels.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <input_folder> <output_folder>");
                return;
            }

            string inputFolder = args[0];
            string outputFolder = args[1];

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"Input folder does not exist: {inputFolder}");
                return;
            }

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlPath in htmlFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(htmlPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // ✔ Load document
                HTMLDocument document = new HTMLDocument(htmlPath);
                // ✔ Configure image options
                ImageSaveOptions options = new ImageSaveOptions();
                // ✔ Convert to PNG
                Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"Converted: {htmlPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}