// Configure XpsSaveOptions to use A4 page size and 1‑centimeter margins for HTML to XPS conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string documentPath = "sample.html";
            string savePath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            // Configure XPS save options with A4 size and 1 cm margins
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.27f),
                    Aspose.Html.Drawing.Length.FromInches(11.69f)
                ),
                new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromCentimeters(1),
                    Aspose.Html.Drawing.Length.FromCentimeters(1),
                    Aspose.Html.Drawing.Length.FromCentimeters(1),
                    Aspose.Html.Drawing.Length.FromCentimeters(1)
                )
            );

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}