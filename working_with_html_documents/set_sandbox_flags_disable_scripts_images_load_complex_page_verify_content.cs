// Set sandbox flags to disable both scripts and images, load a complex page, and verify content.

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
            string htmlContent = "<html><body><div id=\"test\">Hello, Aspose!</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("test");
                string text = element != null ? element.TextContent : null;
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}