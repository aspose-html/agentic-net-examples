// Set a maximum file size limit for individual HTML outputs to manage storage constraints.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(url);
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;

            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}