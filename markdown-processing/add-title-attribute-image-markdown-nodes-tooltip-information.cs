// Add a title attribute to image markdown nodes to provide additional tooltip information.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Sample <img src='image.png' alt='Sample Image'></p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    string title = string.IsNullOrWhiteSpace(alt) ? "Image" : alt;
                    img.SetAttribute("title", title);
                }
            }
            document.Save("output.html");
            Console.WriteLine("Image title attributes added and saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}