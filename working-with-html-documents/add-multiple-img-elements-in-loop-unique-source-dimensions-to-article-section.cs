// Add multiple img elements in a loop, each with unique source and dimensions, to the article section.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create an HTML document with inline content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>";
            var doc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Create an <article> element
            Aspose.Html.HTMLElement article = (Aspose.Html.HTMLElement)doc.CreateElement("article");

            // Add multiple <img> elements in a loop
            for (int i = 1; i <= 5; i++)
            {
                // Create an <img> element
                Aspose.Html.Dom.Element element = doc.CreateElement("img");
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)element;

                // Set unique source, alt text, width, and height
                img.Src = $"image{i}.png";
                img.Alt = $"Image {i}";
                img.Width = 100 * i;
                img.Height = 80 * i;

                // Append the image to the article
                article.AppendChild(img);
            }

            // Append the article to the body
            body.AppendChild(article);

            // Save the document to a file
            doc.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}