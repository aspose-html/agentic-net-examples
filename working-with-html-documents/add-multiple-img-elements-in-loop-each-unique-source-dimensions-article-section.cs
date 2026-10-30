// Add multiple img elements in a loop, each with unique source and dimensions, to the article section.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML content with a basic structure
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>";
            // Create a new HTML document from the content
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Create an article element
            Aspose.Html.HTMLElement article = (Aspose.Html.HTMLElement)doc.CreateElement("article");
            body.AppendChild(article);

            // Add multiple images in a loop
            for (int i = 1; i <= 5; i++)
            {
                Aspose.Html.Dom.Element element = doc.CreateElement("img");
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)element;
                img.Src = $"image{i}.png";
                img.Alt = $"Image {i}";
                img.Width = 100 * i;
                img.Height = 80 * i;
                article.AppendChild(img);
            }

            // Save the resulting HTML to a file
            doc.Save("output.html");
            Console.WriteLine("HTML document saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}