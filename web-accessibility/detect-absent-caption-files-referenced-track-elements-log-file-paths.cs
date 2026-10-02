// Detect absent caption files referenced by <track> elements and log their file paths.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string logPath = "missing_captions.log";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body><video controls><track src=\"missing1.vtt\" kind=\"subtitles\" srclang=\"en\" label=\"English\"><track src=\"existing.vtt\" kind=\"subtitles\" srclang=\"en\" label=\"English\"></video></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
                // Create an existing caption file for demonstration
                System.IO.File.WriteAllText("existing.vtt", "WEBVTT\n\n00:00.000 --> 00:05.000\nHello");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // Find all <track> elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//track", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);

            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.Dom.Element element = node as Aspose.Html.Dom.Element;
                if (element != null)
                {
                    string src = element.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        // Resolve the caption file path relative to the HTML file location
                        string baseDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(inputPath));
                        string captionPath = System.IO.Path.Combine(baseDir, src);
                        if (!System.IO.File.Exists(captionPath))
                        {
                            System.IO.File.AppendAllText(logPath, captionPath + System.Environment.NewLine);
                        }
                    }
                }
            }

            System.Console.WriteLine("Processing completed. Check log at " + logPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}