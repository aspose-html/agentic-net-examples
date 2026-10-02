// Ensure each list is preceded by a blank line to conform with Markdown spacing conventions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string markdownPath = "sample.md";

            // Create a new HTML document
            var doc = new Aspose.Html.HTMLDocument();

            var body = doc.Body;

            // Create and configure <h1>
            var h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            h1.SetAttribute("id", "title");
            h1.AppendChild(doc.CreateTextNode("Sample Document"));
            body.AppendChild(h1);

            // Create and configure <h2>
            var h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            h2.SetAttribute("id", "subtitle");
            h2.AppendChild(doc.CreateTextNode("Section"));
            body.AppendChild(h2);

            // Create <ul> with two <li> items
            var ul = (Aspose.Html.HTMLElement)doc.CreateElement("ul");

            var li1 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            var a1 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a1.SetAttribute("href", "https://example.com");
            a1.AppendChild(doc.CreateTextNode("Example Link"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            var li2 = (Aspose.Html.HTMLElement)doc.CreateElement("li");
            var a2 = (Aspose.Html.HTMLAnchorElement)doc.CreateElement("a");
            a2.SetAttribute("href", "https://example.org");
            a2.AppendChild(doc.CreateTextNode("Another Link"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            var firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            // Save the HTML document to a file
            doc.Save(htmlPath);

            // Convert the saved HTML file to Markdown
            var options = new Aspose.Html.Saving.MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            Console.WriteLine("Conversion completed. Markdown saved to " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}