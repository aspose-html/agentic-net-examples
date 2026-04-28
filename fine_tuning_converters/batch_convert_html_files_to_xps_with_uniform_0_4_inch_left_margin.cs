// Batch convert a set of HTML files to XPS, applying a uniform 0.4‑inch left margin to each file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputXps";
            Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    XpsSaveOptions options = new XpsSaveOptions();
                    options.PageSetup.AnyPage = new Page(
                        new Size(Length.FromInches(8.5f), Length.FromInches(11f)),
                        new Margin(Length.FromInches(0), Length.FromInches(0.4f), Length.FromInches(0), Length.FromInches(0))
                    );

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".xps");
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}