// Provide a CLI option to limit the maximum number of resources extracted per page.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        // Expected arguments: URL, output file path, maximum handling depth
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <url> <outputPath> <maxDepth>");
            return;
        }

        string url = args[0];
        string outputPath = args[1];
        if (!int.TryParse(args[2], out int maxDepth) || maxDepth < 0)
        {
            Console.WriteLine("Invalid maxDepth value.");
            return;
        }

        try
        {
            // Load the web page from the specified URL
            HTMLDocument document = new HTMLDocument(url);

            // Create save options and limit the resource handling depth
            HTMLSaveOptions options = new HTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = maxDepth;

            // Save the document with the configured options
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}