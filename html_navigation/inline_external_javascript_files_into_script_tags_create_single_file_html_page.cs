// Inline external JavaScript files into script tags to create a single‑file HTML page.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

namespace InlineJsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://example.com";
                string outputPath = "single_file.html";

                HTMLDocument document = new HTMLDocument(url);
                HTMLSaveOptions options = new HTMLSaveOptions();
                options.ResourceHandlingOptions.JavaScript = ResourceHandling.Embed;
                document.Save(outputPath, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}