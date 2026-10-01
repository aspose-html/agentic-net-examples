// Configure sandbox to allow images, load a page with mixed content, and verify only images load.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><head><script src='test.js'></script><link rel='stylesheet' href='style.css'></head><body><img src='image.jpg' alt='test'><p>Text</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var images = document.GetElementsByTagName("img");
                int imageCount = images.Length;
                System.Console.WriteLine("Image elements count: " + imageCount);

                var scripts = document.GetElementsByTagName("script");
                int scriptCount = scripts.Length;
                System.Console.WriteLine("Script elements count (should be present but not loaded): " + scriptCount);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}