// Use HTMLDocument.CreateElement to create an img element, set attributes, and prepend to the body.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Get the <body> element
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Create an <img> element and set its attributes
            var img = document.CreateElement("img");
            img.SetAttribute("src", "https://example.com/image.png");
            img.SetAttribute("alt", "Example Image");
            img.SetAttribute("width", "200");
            img.SetAttribute("height", "100");

            // Prepend the image to the body
            var firstChild = body.FirstChild;
            if (firstChild != null)
            {
                body.InsertBefore((Aspose.Html.Dom.Node)img, firstChild);
            }
            else
            {
                body.AppendChild((Aspose.Html.Dom.Node)img);
            }

            // Save the modified document to a file
            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save("output.html", options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}