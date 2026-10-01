// Access the document's Images collection to iterate over all <img> elements.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><img src='image1.png'/><img src='image2.jpg'/></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element img in images)
            {
                string src = img.GetAttribute("src");
                Console.WriteLine("Image src: " + src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}