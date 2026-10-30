// Convert all <i> tags to <em> tags for better accessibility compliance throughout the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>This is <i>italic</i> text and another <i>example</i>.</p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection iElements = document.GetElementsByTagName("i");
                for (int idx = iElements.Length - 1; idx >= 0; idx--)
                {
                    Aspose.Html.HTMLElement iElement = (Aspose.Html.HTMLElement)iElements[idx];
                    Aspose.Html.HTMLElement emElement = (Aspose.Html.HTMLElement)document.CreateElement("em");
                    emElement.InnerHTML = iElement.InnerHTML;
                    iElement.ParentNode.ReplaceChild(emElement, iElement);
                }

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine($"Converted document saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}