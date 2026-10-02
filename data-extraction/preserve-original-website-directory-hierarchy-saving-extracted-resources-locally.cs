// Preserve the original website directory hierarchy when saving extracted resources locally.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input files
            string currentDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(currentDir, "input");
            Directory.CreateDirectory(inputDir);
            string imagesDir = Path.Combine(inputDir, "images");
            Directory.CreateDirectory(imagesDir);

            string imagePath = Path.Combine(imagesDir, "pic.png");
            File.WriteAllBytes(imagePath, new byte[0]); // dummy image

            string htmlContent = "<html><body><img src=\"images/pic.png\" /></body></html>";
            string htmlPath = Path.Combine(inputDir, "index.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure save options to preserve directory hierarchy
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;
            options.ResourceHandlingOptions.PageUrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

            // Save the document with extracted resources
            string outputDir = Path.Combine(currentDir, "output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "saved.html");
            document.Save(outputPath, options);

            Console.WriteLine("Document saved successfully to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}