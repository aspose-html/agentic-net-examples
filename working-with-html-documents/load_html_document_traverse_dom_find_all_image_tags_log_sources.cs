// Load an HTML document, traverse its DOM to find all image tags, and log their sources.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlFilePath = "sample.html";
            if (!File.Exists(htmlFilePath))
            {
                string sampleHtml = "<html><body><img src=\"image1.png\"/><img src=\"image2.jpg\"/></body></html>";
                File.WriteAllText(htmlFilePath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath);
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element image in images)
            {
                string src = image.GetAttribute("src");
                Console.WriteLine(src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}