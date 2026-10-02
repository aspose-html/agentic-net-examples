// Batch convert HTML files to JPG, logging each file's resolution and background color settings for audit.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "OutputJpg");
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if none exist
            string[] sampleFiles = new string[] { "sample1.html", "sample2.html" };
            foreach (string fileName in sampleFiles)
            {
                string filePath = System.IO.Path.Combine(inputFolder, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>" + fileName + "</h1></body></html>";
                    System.IO.File.WriteAllText(filePath, htmlContent);
                }
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (var document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.Beige;

                    string outputPath = System.IO.Path.Combine(outputFolder,
                        System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                    Console.WriteLine($"Resolution: {options.HorizontalResolution}x{options.VerticalResolution} DPI, BackgroundColor: {options.BackgroundColor}");
                }
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}