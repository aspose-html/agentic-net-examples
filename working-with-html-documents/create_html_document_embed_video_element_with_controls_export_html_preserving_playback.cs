// Create an HTML document, embed a video element with controls, and export to HTML preserving playback.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Video Example</title></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            Aspose.Html.HTMLElement container = (Aspose.Html.HTMLElement)document.CreateElement("div");
            container.InnerHTML = "<video controls src=\"https://example.com/sample.mp4\" width=\"640\" height=\"360\"></video>";

            body.AppendChild(container);

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}