// Provide an option to retain original JavaScript files alongside converted HTML for interactive pages.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

namespace RetainJsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // URL of the web page to download
                string url = "https://example.com";

                // Path where the HTML file will be saved
                string outputPath = "output.html";

                // Load the web page into an HTMLDocument
                HTMLDocument document = new HTMLDocument(url);

                // Create save options (default settings keep JavaScript files linked)
                HTMLSaveOptions options = new HTMLSaveOptions();

                // Save the document; JavaScript files will be retained as separate resources
                document.Save(outputPath, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}