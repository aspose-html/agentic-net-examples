// Render HTML to XPS with custom left margin of 10 millimeters by adjusting XpsRenderingOptions.MarginLeft.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string xpsPath = "output.xps";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = Color.White;

            // Page size: 8.5 x 11 inches, left margin ~10 mm (≈28 points)
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5f),
                    Aspose.Html.Drawing.Length.FromInches(11f)),
                new Aspose.Html.Drawing.Margin(28, 0, 0, 0));

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, xpsPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}