// Create a new HTML document, set its language attribute to French, and save as UTF-8 HTML.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var htmlElements = document.GetElementsByTagName("html");
                foreach (Aspose.Html.Dom.Element html in htmlElements)
                {
                    html.SetAttribute("lang", "fr");
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}