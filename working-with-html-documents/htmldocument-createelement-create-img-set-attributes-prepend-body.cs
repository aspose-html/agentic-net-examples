// Use HTMLDocument.CreateElement to create an img element, set attributes, and prepend to the body.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Get the <body> element
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Create an <img> element
            var img = document.CreateElement("img");
            img.SetAttribute("src", "https://example.com/image.png");
            img.SetAttribute("alt", "Sample Image");
            img.SetAttribute("width", "200");
            img.SetAttribute("height", "150");

            // Prepend the image to the body
            if (body.FirstChild != null)
                body.InsertBefore(img, body.FirstChild);
            else
                body.AppendChild(img);

            // Save the document
            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save("output.html", options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}