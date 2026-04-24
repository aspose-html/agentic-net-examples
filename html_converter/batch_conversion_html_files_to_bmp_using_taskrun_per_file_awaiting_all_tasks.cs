// Perform batch conversion of HTML files to BMP using Task.Run for each file and awaiting all tasks.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define input and output folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputBmp";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files in the input folder
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            // List to hold conversion tasks
            List<Task> conversionTasks = new List<Task>();

            // Create a task for each HTML file
            foreach (string htmlPath in htmlFiles)
            {
                conversionTasks.Add(Task.Run(() =>
                {
                    // Load the HTML document
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // Set BMP image save options
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                        // Determine output BMP file path
                        string outputPath = Path.Combine(
                            outputFolder,
                            Path.GetFileNameWithoutExtension(htmlPath) + ".bmp");

                        // Perform the conversion
                        Converter.ConvertHTML(document, options, outputPath);
                    }
                }));
            }

            // Wait for all conversions to complete
            await Task.WhenAll(conversionTasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}