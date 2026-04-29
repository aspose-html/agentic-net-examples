// Configure ImageSaveOptions for PNG output with antialiasing enabled to improve visual quality.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            var document = new HTMLDocument("input.html");

            // Create image save options (PNG is default) and enable antialiasing
            var options = new ImageSaveOptions();
            options.UseAntialiasing = true;

            // Convert the HTML document to a PNG image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}