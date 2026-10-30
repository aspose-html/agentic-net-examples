// Load an HTML document, traverse its DOM to find all image tags, and log their sources.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><img src='image1.png'><img src='https://example.com/image2.jpg'></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element image in images)
            {
                string src = image.GetAttribute("src");
                System.Console.WriteLine(src);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}