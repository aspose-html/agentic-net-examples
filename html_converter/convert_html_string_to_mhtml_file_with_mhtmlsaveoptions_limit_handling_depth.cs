// Convert an HTML string to an MHTML file with MHTMLSaveOptions configured to limit handling depth.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToMhtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                string baseUri = "http://example.com/";
                string outputPath = "output.mht";

                MHTMLSaveOptions options = new MHTMLSaveOptions();
                options.ResourceHandlingOptions.MaxHandlingDepth = 1;

                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}