// Batch convert a directory of HTML files to JPG images with uniform dimensions using ImageDevice.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if the input folder is empty
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    // Configure image rendering options for JPEG with uniform dimensions
                    Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                        new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;

                    // Determine output image path
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    // Render the document to an image file
                    Aspose.Html.Rendering.Image.ImageDevice device =
                        new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}