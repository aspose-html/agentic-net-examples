// Load an HTML file, replace all <i> tags with <em> tags, and save the updated file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><p>This is <i>italic</i> text and another <i>example</i>.</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get all <i> elements
                var iElements = document.GetElementsByTagName("i");

                // Iterate backwards to safely replace elements
                for (int idx = iElements.Length - 1; idx >= 0; idx--)
                {
                    Element iElement = iElements[idx];
                    HTMLElement iHtmlElement = iElement as HTMLElement;

                    // Create a new <em> element
                    Element emElement = document.CreateElement("em");
                    HTMLElement emHtmlElement = emElement as HTMLElement;

                    // Transfer inner HTML from <i> to <em>
                    if (iHtmlElement != null && emHtmlElement != null)
                    {
                        emHtmlElement.InnerHTML = iHtmlElement.InnerHTML;
                    }

                    // Replace the <i> element with the new <em> element
                    if (iElement.ParentNode != null)
                    {
                        iElement.ParentNode.ReplaceChild(emElement, iElement);
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }

            Console.WriteLine("HTML file processed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}