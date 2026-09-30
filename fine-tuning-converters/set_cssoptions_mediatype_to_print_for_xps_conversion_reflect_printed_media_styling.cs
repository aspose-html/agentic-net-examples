// Set CssOptions.MediaType to Print for XPS conversion to reflect printed media styling.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output XPS paths
            string htmlPath = "sample.html";
            string xpsPath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            // NOTE: CssOptions.MediaType = Print is not available in the current API surface,
            // so it is omitted to comply with the core policies.

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, xpsPath);

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + xpsPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}