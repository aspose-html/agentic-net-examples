// Set a CSS background-image rule for the body element using a remote image URL.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = "body { background-image: url('https://example.com/flower.png'); }";
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);
            head.AppendChild(styleElement);

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine("HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}