// Add a custom data‑attribute to all heading elements for JavaScript interaction later.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new HTML document
                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

                // Get the body element
                var body = doc.Body;

                // Create H1 heading with custom data attribute
                var h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
                h1.SetAttribute("data-custom", "heading1");
                h1.AppendChild(doc.CreateTextNode("Sample Heading 1"));
                body.AppendChild(h1);

                // Create H2 heading with custom data attribute
                var h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
                h2.SetAttribute("data-custom", "heading2");
                h2.AppendChild(doc.CreateTextNode("Sample Heading 2"));
                body.AppendChild(h2);

                // Save the document
                string outputPath = "output.html";
                doc.Save(outputPath);
                Console.WriteLine($"Document saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}