// Generate a localized HTML page by binding language‑specific strings from an XML resource file.

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string xmlPath = "Resources/strings.xml";
            string templatePath = "template.html";
            string outputPath = "localized.html";

            // Load localized strings from XML
            XDocument xmlDoc = XDocument.Load(xmlPath);
            string titleText = xmlDoc.Root.Element("title")?.Value ?? "";
            string messageText = xmlDoc.Root.Element("message")?.Value ?? "";

            // Load HTML template content
            string htmlContent = File.ReadAllText(templatePath, System.Text.Encoding.UTF8);
            string baseUri = Path.GetDirectoryName(Path.GetFullPath(templatePath));

            // Create HTMLDocument from content and base URI
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Bind title
            var titleElement = (HTMLElement)document.GetElementsByTagName("span").FirstOrDefault();
            if (titleElement != null)
                titleElement.TextContent = titleText;

            // Bind message
            var messageElement = (HTMLElement)document.GetElementsByTagName("p").FirstOrDefault();
            if (messageElement != null)
                messageElement.TextContent = messageText;

            // Save localized HTML
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}