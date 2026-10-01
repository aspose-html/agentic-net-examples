// Set a timeout limit for loading website resources to prevent excessively long conversions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define the URL to load and the output file path
            string url = "https://example.com";
            string outputPath = "output.html";

            // Create a request message with a timeout
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(10);

            // Load the HTML document from the request
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                // Optional: retrieve the outer HTML of the document
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine($"Document loaded. Length: {html.Length}");

                // Configure save options
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                options.ResourceHandlingOptions.MaxHandlingDepth = 5;

                // Save the document to the specified file
                document.Save(outputPath, options);
                Console.WriteLine($"Document saved to: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}