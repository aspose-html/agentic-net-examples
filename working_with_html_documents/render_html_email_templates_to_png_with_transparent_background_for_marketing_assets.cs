// Render HTML email templates to PNG with a transparent background for use in marketing assets.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.Drawing;

namespace HtmlToPngExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
                string baseUri = Environment.CurrentDirectory;
                ImageSaveOptions options = new ImageSaveOptions();
                options.BackgroundColor = Color.Transparent;
                string outputPath = "email_template.png";

                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
                Console.WriteLine($"HTML email template rendered to PNG at: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}