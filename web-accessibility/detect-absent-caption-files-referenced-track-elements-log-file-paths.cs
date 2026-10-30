// Detect absent caption files referenced by <track> elements and log their file paths.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string logPath = "missing_captions.log";

            // Create a minimal HTML file with a <track> element referencing a non‑existent caption file
            string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                                "<video controls>" +
                                "<source src=\"video.mp4\" type=\"video/mp4\">" +
                                "<track src=\"missing.vtt\" kind=\"subtitles\" srclang=\"en\" label=\"English\">" +
                                "</video>" +
                                "</body></html>";
            File.WriteAllText(inputPath, sampleHtml);

            // Ensure the log file is empty before starting
            if (File.Exists(logPath))
                File.Delete(logPath);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Find all <track> elements
            IXPathResult result = document.Evaluate("//track", document, document.CreateNSResolver(document), XPathResultType.Any, null);

            Node node;
            while ((node = result.IterateNext()) != null)
            {
                Element element = node as Element;
                if (element != null)
                {
                    string src = element.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src) && !File.Exists(src))
                    {
                        File.AppendAllText(logPath, src + Environment.NewLine);
                    }
                }
            }

            Console.WriteLine("Processing completed. Missing caption files (if any) are logged to: " + Path.GetFullPath(logPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}