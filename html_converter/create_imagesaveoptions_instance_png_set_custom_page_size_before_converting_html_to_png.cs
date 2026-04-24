// Create an ImageSaveOptions instance for PNG and set custom page size before converting HTML to PNG.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

namespace HtmlToPngExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
                string baseUri = Environment.CurrentDirectory;
                string outputPath = "output.png";

                ImageSaveOptions options = new ImageSaveOptions();
                options.PageSetup.AnyPage = new Page(new Size(800, 600));

                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}