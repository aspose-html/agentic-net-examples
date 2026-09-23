// Use HtmlDocument.QuerySelectorAll with CSS selector "img[data-important='true']" to target specific images.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body>" +
                                 "<img src='image1.jpg' data-important='true'/>" +
                                 "<img src='image2.jpg'/>" +
                                 "<img src='image3.png' data-important='true'/>" +
                                 "</body></html>";

            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.NodeList images = document.QuerySelectorAll("img[data-important='true']");

                foreach (Aspose.Html.Dom.Element img in images)
                {
                    string src = img.GetAttribute("src");
                    Console.WriteLine("Important image src: " + src);
                }
            }

            File.Delete(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}