// Insert a new meta tag for character encoding into the head section of the HTML document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head></head><body><p>Hello World</p></body></html>";
            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the <head> element
            Aspose.Html.Dom.Element headElement = document.QuerySelector("head");
            Aspose.Html.HTMLHeadElement head = headElement as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                // Insert the new head before the body element
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Create new meta tag for character encoding
            Aspose.Html.Dom.Element meta = document.CreateElement("meta");
            meta.SetAttribute("charset", "UTF-8");

            // Append meta tag to head
            head.AppendChild(meta);

            // Save the modified HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine("Meta tag inserted and HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}