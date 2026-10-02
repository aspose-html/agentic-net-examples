// Create a <style> element with CSS rules, append it to the HTML head, and generate the final document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a <style> element
            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = "body { background-color: #f0f0f0; } h1 { color: blue; }";
            Aspose.Html.Dom.Text cssNode = document.CreateTextNode(css);
            styleElement.AppendChild(cssNode);

            // Get the <head> element, create it if missing
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }
            head.AppendChild(styleElement);

            // Add sample content to the body
            Aspose.Html.HTMLElement body = document.Body as Aspose.Html.HTMLElement;
            Aspose.Html.HTMLElement h1 = (Aspose.Html.HTMLElement)document.CreateElement("h1");
            Aspose.Html.Dom.Text textNode = document.CreateTextNode("Hello, Aspose.HTML!");
            h1.AppendChild(textNode);
            body.AppendChild(h1);

            // Save the document
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}