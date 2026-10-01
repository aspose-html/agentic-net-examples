// Ensure each list is preceded by a blank line to conform with Markdown spacing conventions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Convert HTML file to Markdown
            string markdownPath = "output.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Create a new HTML document and manipulate DOM
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            var body = doc.Body;

            var h1 = doc.CreateElement("h1");
            h1.SetAttribute("style", "color:blue;");
            h1.AppendChild(doc.CreateTextNode("First Heading"));
            body.AppendChild(h1);

            var h2 = doc.CreateElement("h2");
            h2.SetAttribute("style", "color:green;");
            h2.AppendChild(doc.CreateTextNode("Second Heading"));
            body.AppendChild(h2);

            var ul = doc.CreateElement("ul");

            var li1 = doc.CreateElement("li");
            var a1 = doc.CreateElement("a");
            a1.SetAttribute("href", "https://example.com/1");
            a1.AppendChild(doc.CreateTextNode("Link 1"));
            li1.AppendChild(a1);
            ul.AppendChild(li1);

            var li2 = doc.CreateElement("li");
            var a2 = doc.CreateElement("a");
            a2.SetAttribute("href", "https://example.com/2");
            a2.AppendChild(doc.CreateTextNode("Link 2"));
            li2.AppendChild(a2);
            ul.AppendChild(li2);

            var firstChild = body.FirstChild;
            if (firstChild != null)
                body.InsertBefore(ul, firstChild);
            else
                body.AppendChild(ul);

            string outputHtmlPath = "modified.html";
            doc.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}