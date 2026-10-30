// Use HtmlDocument.QuerySelectorAll with CSS selector "img[data-important='true']" to target specific images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<html><body>" +
                          "<img src='image1.jpg' data-important='true'/>" +
                          "<img src='image2.jpg'/>" +
                          "<img src='image3.png' data-important='true'/>" +
                          "</body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.NodeList importantImages = document.QuerySelectorAll("img[data-important='true']");

                Console.WriteLine($"Found {importantImages.Length} important image(s).");

                for (int i = 0; i < importantImages.Length; i++)
                {
                    Aspose.Html.Dom.Node node = importantImages[i];
                    if (node.NodeType == Aspose.Html.Dom.Node.ELEMENT_NODE)
                    {
                        Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)node;
                        string src = element.GetAttribute("src");
                        Console.WriteLine($"Image {i + 1} src: {src}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}