// Use HTMLDocument.CreateElement to create an img element, set attributes, and prepend to the body.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Create a new empty HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Get the <body> element
            var body = (Aspose.Html.HTMLElement)Enumerable.First(document.GetElementsByTagName("body"));

            // Create an <img> element and set its attributes
            var img = document.CreateElement("img");
            img.SetAttribute("src", "https://example.com/image.png");
            img.SetAttribute("alt", "Sample Image");
            img.SetAttribute("width", "200");
            img.SetAttribute("height", "100");

            // Append the image to the body
            body.AppendChild(img);

            // Save the document to a file with default HTML save options
            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, options);

            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}