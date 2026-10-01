// Create an HTML document, add a meta viewport for responsive design, and test on mobile rendering.

using System;

namespace AsposeHtmlMetaViewportExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new empty HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create <html>, <head>, and <body> elements
                Aspose.Html.Dom.Element htmlElement = document.CreateElement("html");
                Aspose.Html.Dom.Element headElement = document.CreateElement("head");
                Aspose.Html.Dom.Element bodyElement = document.CreateElement("body");

                // Build the DOM hierarchy: document -> html -> head & body
                document.AppendChild(htmlElement);
                htmlElement.AppendChild(headElement);
                htmlElement.AppendChild(bodyElement);

                // Create the meta viewport tag and set its attributes
                Aspose.Html.Dom.Element metaViewport = document.CreateElement("meta");
                metaViewport.SetAttribute("name", "viewport");
                metaViewport.SetAttribute("content", "width=device-width, initial-scale=1.0");
                headElement.AppendChild(metaViewport);

                // Add a sample paragraph to the body
                Aspose.Html.Dom.Element paragraph = document.CreateElement("p");
                // Cast to HTMLElement to use InnerHTML
                Aspose.Html.HTMLElement htmlParagraph = (Aspose.Html.HTMLElement)paragraph;
                htmlParagraph.InnerHTML = "Responsive meta viewport added.";
                bodyElement.AppendChild(paragraph);

                // Save the HTML document to a file
                string outputPath = "responsive.html";
                document.Save(outputPath);
                Console.WriteLine($"HTML document saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}