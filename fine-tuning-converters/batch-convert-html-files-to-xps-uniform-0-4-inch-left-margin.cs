// Batch convert a set of HTML files to XPS, applying a uniform 0.4‑inch left margin to each file.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputXps";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromInches(8.5),
                            Aspose.Html.Drawing.Length.FromInches(11)),
                        new Aspose.Html.Drawing.Margin(
                            Aspose.Html.Drawing.Length.FromInches(0.4),
                            Aspose.Html.Drawing.Length.FromInches(0),
                            Aspose.Html.Drawing.Length.FromInches(0),
                            Aspose.Html.Drawing.Length.FromInches(0)));

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".xps");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}