// Load an HTML document, traverse its DOM to find all image tags, and log their sources.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src='image1.png'/><img src='https://example.com/image2.jpg'/></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                foreach (Aspose.Html.Dom.Element image in images)
                {
                    string src = image.GetAttribute("src");
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}