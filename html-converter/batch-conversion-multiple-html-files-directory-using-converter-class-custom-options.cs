// Perform batch conversion of multiple HTML files in a directory using the Converter class with custom options.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output folders
            string inputFolder = "input";
            string outputFolder = "output";

            // Ensure folders exist
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if they do not exist
            string sample1Path = System.IO.Path.Combine(inputFolder, "sample1.html");
            if (!System.IO.File.Exists(sample1Path))
            {
                System.IO.File.WriteAllText(sample1Path, "<html><body><h1>Sample 1</h1></body></html>");
            }

            string sample2Path = System.IO.Path.Combine(inputFolder, "sample2.html");
            if (!System.IO.File.Exists(sample2Path))
            {
                System.IO.File.WriteAllText(sample2Path, "<html><body><h1>Sample 2</h1></body></html>");
            }

            // Batch conversion: HTML to JPEG images
            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    // Configure image save options (JPEG format)
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    // Example of custom options: set resolution
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;

                    // Determine output image path
                    string outputPath = System.IO.Path.Combine(
                        outputFolder,
                        System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");

                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}