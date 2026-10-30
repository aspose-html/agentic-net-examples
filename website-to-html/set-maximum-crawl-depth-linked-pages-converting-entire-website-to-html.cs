// Set the maximum crawl depth for linked pages when converting an entire website to HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input URL of the page to convert
            string sourceUrl = "https://example.com";

            // Output HTML file path
            string outputPath = "output.html";

            // Load the HTML document from the URL
            var document = new Aspose.Html.HTMLDocument(sourceUrl);

            // Configure HTML save options with maximum handling depth
            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 2; // Limits resource handling depth for the document.

            // Save the document as a local HTML file
            document.Save(outputPath, options);

            Console.WriteLine($"Conversion completed successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}