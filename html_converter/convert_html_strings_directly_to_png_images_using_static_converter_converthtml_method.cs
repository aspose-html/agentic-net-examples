// Convert HTML strings directly to PNG images using the static Converter.ConvertHTML method.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPngExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                string baseUri = "file:///";
                string outputPath = "output.png";

                ImageSaveOptions options = new ImageSaveOptions();

                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
                Console.WriteLine("Conversion completed. PNG saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}