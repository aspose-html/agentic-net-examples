// Log a summary of all extracted resources, including type and file path, after extraction.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string logPath = "extraction_log.txt";
            File.WriteAllText(logPath, "Extraction Log" + Environment.NewLine);
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument("sample.html");
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node;
            int count = 0;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                File.AppendAllText(logPath, $"Image: {img.Src}" + Environment.NewLine);
                count++;
            }
            File.AppendAllText(logPath, $"Total images extracted: {count}" + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}