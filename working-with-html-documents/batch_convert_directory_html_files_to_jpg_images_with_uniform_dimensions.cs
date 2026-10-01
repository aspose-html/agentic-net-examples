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
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            // Batch conversion: convert each .html file to JPEG
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Single conversion with custom resolution
            string anotherHtmlPath = Path.Combine(inputFolder, "another.html");
            File.WriteAllText(anotherHtmlPath, "<html><body><p>Another file</p></body></html>");
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(anotherHtmlPath, Directory.GetCurrentDirectory()))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 150;
                options.VerticalResolution = 150;

                string outPath = Path.Combine(outputFolder, "another.jpg");
                Aspose.Html.Converters.Converter.ConvertHTML(doc, options, outPath);
            }

            // Conversion from HTML string directly
            string htmlContent = "<html><body><h2>String content</h2></body></html>";
            string baseUri = Directory.GetCurrentDirectory();
            string stringOutputPath = Path.Combine(outputFolder, "stringContent.jpg");
            var stringOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, stringOptions, stringOutputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}