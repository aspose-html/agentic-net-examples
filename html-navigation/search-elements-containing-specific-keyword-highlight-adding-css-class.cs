// Search for elements containing a specific keyword and highlight them by adding a CSS class.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head></head><body><p>This is a sample paragraph with the keyword.</p><div>Another element containing keyword.</div><span>No match here.</span></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create and append a style element for the highlight class
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = ".highlight { background-color: yellow; }";
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head")[0];
            head.AppendChild(styleElement);

            // Keyword to search for
            string keyword = "keyword";

            // Get all elements in the document
            Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");

            // Iterate over elements and add the highlight class where the keyword is found
            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.HTMLElement element = allElements[i] as Aspose.Html.HTMLElement;
                if (element != null && element.InnerHTML != null && element.InnerHTML.Contains(keyword))
                {
                    string existingClass = element.GetAttribute("class");
                    string newClass = string.IsNullOrEmpty(existingClass) ? "highlight" : existingClass + " highlight";
                    element.SetAttribute("class", newClass);
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine("Document processed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}