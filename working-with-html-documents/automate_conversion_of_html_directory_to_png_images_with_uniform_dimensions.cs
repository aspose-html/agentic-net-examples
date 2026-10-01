// Automate conversion of a directory of HTML files to PNG images with uniform dimensions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Prepare input directory and sample HTML file
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            Directory.CreateDirectory(inputDir);
            string sampleHtmlPath = Path.Combine(inputDir, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            // Input files
            string[] inputs = new string[] { sampleHtmlPath };

            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                using (var document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    // Configure image options
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpeg");

                    // Convert
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed. Output files are in: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}