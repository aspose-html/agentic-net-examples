// Render an HTML document to PNG with a background color specified in CSS and custom DPI.

using System;
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
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Path where the PNG image will be saved
            string outputPath = "output.png";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure image rendering options
            ImageSaveOptions options = new ImageSaveOptions();
            options.UseAntialiasing = false;
            options.HorizontalResolution = 150; // DPI X
            options.VerticalResolution = 150;   // DPI Y
            options.BackgroundColor = Color.Beige; // Canvas background color

            // Convert HTML to PNG with the specified options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}