// Define custom page orientation landscape in ImageSaveOptions before converting HTML to XPS for wide layouts.

using System;
using System.IO;
using System.Drawing;
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
            // Define input and output paths
            string inputPath = "sample.html";
            string outputPath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Wide Layout</title></head><body><div style='width:1000px;height:200px;background:#ffcc00;'>Wide Content</div></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure XPS save options with landscape orientation
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Define a landscape page (width > height) using inches
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),   // width
                    Aspose.Html.Drawing.Length.FromInches(8.5)   // height
                ),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0)
            );
            options.PageSetup.AnyPage = page;

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}