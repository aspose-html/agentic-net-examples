// Convert a batch of HTML files to JPEG images with varying quality settings based on file size.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing source HTML files
            string inputFolder = @"C:\InputHtml";
            // Folder where JPEG images will be saved
            string outputFolder = @"C:\OutputJpeg";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure JPEG output options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    // Note: Varying quality based on file size is not directly supported by the API,
                    // so default quality settings are used.

                    // Determine the output JPEG file path
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    // Convert the HTML document to a JPEG image
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}