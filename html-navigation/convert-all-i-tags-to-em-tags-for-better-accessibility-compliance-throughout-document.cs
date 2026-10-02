// Convert all <i> tags to <em> tags for better accessibility compliance throughout the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p>This is <i>italic</i> and another <i>example</i>.</p></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all <i> elements
            Aspose.Html.Collections.NodeList iElements = document.QuerySelectorAll("i");

            // Replace each <i> with <em>
            for (int index = 0; index < iElements.Length; index++)
            {
                Aspose.Html.Dom.Node node = iElements[index];
                Aspose.Html.HTMLElement iElement = node as Aspose.Html.HTMLElement;
                if (iElement != null)
                {
                    Aspose.Html.HTMLElement emElement = (Aspose.Html.HTMLElement)document.CreateElement("em");
                    emElement.InnerHTML = iElement.InnerHTML;
                    iElement.ParentNode.ReplaceChild(emElement, iElement);
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine($"Modified HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}