// Load an HTML file and extract image source attributes by selecting img tags with a CSS selector.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";

            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<img src='image1.png'/>" +
                                    "<img src='image2.jpg'/>" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                foreach (Aspose.Html.Dom.Element img in images)
                {
                    string src = img.GetAttribute("src");
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}