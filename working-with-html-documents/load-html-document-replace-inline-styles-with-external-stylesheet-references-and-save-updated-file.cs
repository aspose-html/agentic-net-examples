// Load an HTML document, replace inline styles with external stylesheet references, and save the updated file.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string cssPath = "styles.css";

            // Create sample input HTML with inline style if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head></head><body style=\"background-color:#e5f3fd;\">Hello</body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Create external CSS file
            string cssContent = "body { background-color: #e5f3fd; }";
            File.WriteAllText(cssPath, cssContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Add <link> element referencing the external stylesheet
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head").First();
            Aspose.Html.Dom.Element link = document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", cssPath);
            head.AppendChild(link);

            // Remove inline style attributes from the body element
            Aspose.Html.Dom.Element body = (Aspose.Html.Dom.Element)document.GetElementsByTagName("body").First();
            if (body != null && body.HasAttribute("style"))
            {
                body.RemoveAttribute("style");
            }

            // Save the updated document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}