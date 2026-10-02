// Append a new stylesheet link element to the head to reference an external CSS file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                var htmlElement = document.DocumentElement;
                var body = document.Body;
                htmlElement.InsertBefore(head, body);
            }

            var link = (Aspose.Html.HTMLElement)document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", "styles.css");
            head.AppendChild(link);

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}