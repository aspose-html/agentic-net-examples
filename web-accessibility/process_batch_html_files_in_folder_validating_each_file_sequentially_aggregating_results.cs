// Process a batch of HTML files in a folder, validating each file sequentially and aggregating results.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}