// Apply a naming pattern that prefixes each saved file with the source domain name.

using System;
using Aspose.Html;

namespace AsposeHtmlNamingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Source HTML URL (could be a local file path or a web URL)
                string sourceUrl = "https://example.com/input.html";

                // Load the HTML document from the source URL
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);

                // Extract the domain name from the source URL
                Uri uri = new Uri(sourceUrl);
                string domain = uri.Host;

                // Build the output file name with the domain prefix
                string outputPath = $"{domain}_output.html";

                // Save the document with the prefixed file name
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}