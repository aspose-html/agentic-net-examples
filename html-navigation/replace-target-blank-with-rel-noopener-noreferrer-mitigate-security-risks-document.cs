// Replace target="_blank" attributes with rel="noopener noreferrer" to mitigate security risks in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><a href='https://example.com' target='_blank'>Example Link</a></body></html>";

            // Load HTML document from string using the two‑argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all anchor elements with target="_blank"
            var nodeList = document.QuerySelectorAll("a[target='_blank']");

            // Iterate and set rel attribute
            foreach (var element in nodeList)
            {
                // element is of type Aspose.Html.Dom.Element
                ((Aspose.Html.Dom.Element)element).SetAttribute("rel", "noopener noreferrer");
            }

            // Save the modified document
            string outputPath = "modified.html";
            document.Save(outputPath);

            Console.WriteLine("Document processed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}