// Render HTML email templates to PNG with a transparent background for use in marketing assets.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body style='font-family:Arial;'><h1>Hello World</h1><p>This is an email template.</p></body></html>";
            string baseUri = Directory.GetCurrentDirectory();
            string outputPath = "email.png";

            ImageSaveOptions options = new ImageSaveOptions();
            options.BackgroundColor = Color.Transparent;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("HTML email template rendered to PNG with transparent background at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}