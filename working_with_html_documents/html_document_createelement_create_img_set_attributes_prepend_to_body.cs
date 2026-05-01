// Use HTMLDocument.CreateElement to create an img element, set attributes, and prepend to the body.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Retrieve the first <body> element in the document
            HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();

            // Create an <img> element using the document's CreateElement method
            Aspose.Html.Dom.Element img = document.CreateElement("img");

            // Set required attributes on the image element
            img.SetAttribute("src", "https://example.com/image.png");
            img.SetAttribute("alt", "Example Image");
            img.SetAttribute("width", "200");
            img.SetAttribute("height", "100");

            // Prepend the image to the body (insert before the first child if it exists)
            var firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(img, firstChild);
            else
                body.AppendChild(img); // fallback if body has no children

            // Save the modified document to a file using default HTML save options
            HTMLSaveOptions options = new HTMLSaveOptions();
            document.Save("output.html", options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}