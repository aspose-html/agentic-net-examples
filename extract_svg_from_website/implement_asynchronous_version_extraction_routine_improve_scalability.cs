// Implement an asynchronous version of the extraction routine to improve scalability.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Input HTML file path (first argument or default)
            string htmlPath = args.Length > 0 ? args[0] : "input.html";

            // Log file where extracted image sources will be written
            string logPath = "extraction.log";

            // Load the HTML document from the file system
            HTMLDocument doc = new HTMLDocument(htmlPath);

            // Evaluate XPath to select all <img> elements
            IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            // Iterate over each selected node
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                // Cast the node to an image element
                HTMLImageElement img = (HTMLImageElement)node;

                // Asynchronously append the image source to the log file
                await File.AppendAllTextAsync(logPath, img.Src + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            // Write any errors to the standard error stream
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}