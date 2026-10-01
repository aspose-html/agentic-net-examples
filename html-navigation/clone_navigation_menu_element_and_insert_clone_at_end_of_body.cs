// Clone a navigation menu element and insert the clone at the end of the body.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing a navigation menu
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><nav id='mainNav'><ul><li>Home</li><li>About</li></ul></nav></body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);

            // Find the navigation element
            Aspose.Html.HTMLElement nav = document.QuerySelector("nav") as Aspose.Html.HTMLElement;
            if (nav == null)
            {
                Console.WriteLine("Navigation element not found.");
                return;
            }

            // Clone the navigation element (deep clone)
            Aspose.Html.Dom.Element clonedNav = nav.CloneNode(true) as Aspose.Html.Dom.Element;

            // Get the body element
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Insert the cloned navigation at the end of the body
            body.AppendChild(clonedNav);

            // Save the modified document
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            string outputPath = "output.html";
            document.Save(outputPath, options);

            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}