// Count the number of <img> nodes using XPath and output the total count.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file with images
            string htmlPath = "sample.html";
            string htmlContent = "<html><body>" +
                                 "<img src='image1.png' class='photo'/>" +
                                 "<img src='image2.png'/>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath);

            // Evaluate XPath to select all <img> elements
            Aspose.Html.Dom.XPath.IXPathResult result = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);

            // Iterate over the result nodes and output the Src attribute
            Aspose.Html.Dom.Node node;
            while ((node = result.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                Console.WriteLine(img.Src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}