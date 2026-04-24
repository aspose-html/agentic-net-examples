// Log detailed extraction steps to a file using Serilog for troubleshooting purposes.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the log file
            string logPath = "extraction.log";
            System.IO.File.AppendAllText(logPath, "Extraction started" + Environment.NewLine);

            // Load the HTML document
            HTMLDocument doc = new HTMLDocument("sample.html");
            System.IO.File.AppendAllText(logPath, "HTML document loaded" + Environment.NewLine);

            // Evaluate XPath to select all img elements
            IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
            System.IO.File.AppendAllText(logPath, "XPath evaluation completed" + Environment.NewLine);

            // Iterate over the result nodes and log each image src
            Node node;
            while ((node = result.IterateNext()) != null)
            {
                HTMLImageElement img = (HTMLImageElement)node;
                System.IO.File.AppendAllText(logPath, "Image src: " + img.Src + Environment.NewLine);
            }

            System.IO.File.AppendAllText(logPath, "Extraction finished" + Environment.NewLine);
        }
        catch (Exception ex)
        {
            // Log any errors that occur during processing
            string logPath = "extraction.log";
            System.IO.File.AppendAllText(logPath, "Error: " + ex.Message + Environment.NewLine);
        }
    }
}