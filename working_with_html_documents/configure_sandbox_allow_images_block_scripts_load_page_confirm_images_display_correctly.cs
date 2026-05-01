// Configure sandbox to allow images but block scripts, load a page, and confirm images display correctly.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><img id='testImg' src='https://example.com/image.png' /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var images = document.GetElementsByTagName("img");
                Console.WriteLine($"Found {images.Length} image(s).");
                foreach (Element img in images)
                {
                    string src = img.GetAttribute("src");
                    Console.WriteLine($"Image src: {src}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}