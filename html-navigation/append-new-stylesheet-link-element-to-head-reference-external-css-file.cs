// Append a new stylesheet link element to the head to reference an external CSS file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get or create <head> element
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Create <link rel=\"stylesheet\" href=\"styles.css\">
            Aspose.Html.Dom.Element link = document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", "styles.css");

            // Append the link element to the head
            head.AppendChild(link);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}