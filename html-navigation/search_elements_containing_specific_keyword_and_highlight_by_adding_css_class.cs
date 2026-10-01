// Search for elements containing a specific keyword and highlight them by adding a CSS class.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"<html><head><title>Sample</title></head><body>
                <p>This is a test keyword example.</p>
                <div>Another keyword here.</div>
                <span>No match.</span>
                </body></html>";

            // Load the HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Inject CSS class for highlighting
            Aspose.Html.Dom.Element head = document.QuerySelector("head");
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = ".highlight { background-color: yellow; }";
            head.AppendChild(style);

            // Keyword to search for
            string keyword = "keyword";

            // Find all elements and highlight those containing the keyword
            Aspose.Html.Collections.NodeList allElements = document.QuerySelectorAll("*");
            foreach (Aspose.Html.HTMLElement element in allElements)
            {
                if (!string.IsNullOrEmpty(element.InnerHTML) && element.InnerHTML.Contains(keyword))
                {
                    string existingClass = element.ClassName ?? string.Empty;
                    if (!existingClass.Split(' ').Contains("highlight"))
                    {
                        element.ClassName = (existingClass + " highlight").Trim();
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}