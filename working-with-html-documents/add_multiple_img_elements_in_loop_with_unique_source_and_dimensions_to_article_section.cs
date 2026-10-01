// Add multiple img elements in a loop, each with unique source and dimensions, to the article section.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Create an <img> element
            Aspose.Html.Dom.Element element = doc.CreateElement("img");
            Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)element;

            // Set image attributes
            img.Src = "https://example.com/image.png";
            img.Alt = "Sample Image";
            img.Width = 200;
            img.Height = 100;

            // Append the image to the body
            body.AppendChild(img);

            // Save the document to a file
            doc.Save("output.html");
            Console.WriteLine("HTML document saved as output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}