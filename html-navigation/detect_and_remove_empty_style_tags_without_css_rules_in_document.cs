// Detect and remove empty style tags that contain no CSS rules in the document.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with empty and non-empty style tags
            string htmlContent = "<html><head><style></style><style>body{color:red;}</style></head><body><p>Hello World</p></body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all <style> elements
            Aspose.Html.Collections.HTMLCollection styles = document.GetElementsByTagName("style");

            // Iterate backwards to safely remove elements
            for (int i = styles.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element styleElement = (Aspose.Html.Dom.Element)styles[i];
                string cssContent = styleElement.TextContent;

                if (string.IsNullOrWhiteSpace(cssContent))
                {
                    // Remove empty <style> tag from its parent
                    if (styleElement.ParentNode != null)
                    {
                        styleElement.ParentNode.RemoveChild(styleElement);
                    }
                }
            }

            // Save the modified document
            document.Save("output.html", new Aspose.Html.Saving.HTMLSaveOptions());

            Console.WriteLine("Empty <style> tags removed and document saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}