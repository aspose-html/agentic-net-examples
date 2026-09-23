// Log detailed extraction steps to a file using Serilog for troubleshooting purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define log file path
            string logPath = "extraction.log";
            File.AppendAllText(logPath, "=== Extraction started ===" + Environment.NewLine);

            // Create a minimal HTML file with images
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html><html><body>" +
                                 "<img src='image1.png'/>" +
                                 "<img src='image2.jpg'/>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent);
            File.AppendAllText(logPath, "Created sample HTML file: " + htmlPath + Environment.NewLine);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath);
            File.AppendAllText(logPath, "Loaded HTML document." + Environment.NewLine);

            // Evaluate XPath to select all img elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            File.AppendAllText(logPath, "Evaluated XPath '//img'." + Environment.NewLine);

            // Iterate over the result nodes and log each image src
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                File.AppendAllText(logPath, "Found image src: " + img.Src + Environment.NewLine);
            }

            File.AppendAllText(logPath, "=== Extraction completed ===" + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}