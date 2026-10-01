// Embed a .vtt caption file into the HTML document and reference it via a newly created <track> element.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create an <img> element
            Aspose.Html.Dom.Element imgElement = document.CreateElement("img");
            Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)imgElement;
            img.Src = "https://docs.aspose.com/html/images/aspose-html-for-net.png";
            img.Alt = "Aspose.HTML for .NET Product Logo";
            img.Width = 128;
            img.Height = 128;

            // Append the image to the body
            body.AppendChild(img);

            // Save the document to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}