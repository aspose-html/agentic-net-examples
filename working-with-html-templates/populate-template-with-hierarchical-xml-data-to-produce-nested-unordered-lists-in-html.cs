// Populate a template with hierarchical XML data to produce nested unordered lists in HTML.

using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string xmlPath = "data.xml";
            string templatePath = "template.html";
            string outputPath = "result.html";

            // Create sample XML if it does not exist
            if (!File.Exists(xmlPath))
            {
                string xmlContent = @"<root>
  <category name=""Fruits"">
    <item>Apple</item>
    <item>Banana</item>
  </category>
  <category name=""Vegetables"">
    <item>Carrot</item>
    <item>Broccoli</item>
  </category>
</root>";
                File.WriteAllText(xmlPath, xmlContent);
            }

            // Create sample HTML template if it does not exist
            if (!File.Exists(templatePath))
            {
                string htmlTemplate = @"<html><head><title>Sample</title></head><body><div id=""content""></div></body></html>";
                File.WriteAllText(templatePath, htmlTemplate);
            }

            // Load XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode rootNode = xmlDoc.DocumentElement;

            // Load HTML template
            var document = new Aspose.Html.HTMLDocument(templatePath, new Aspose.Html.Configuration());

            // Create the top-level unordered list
            var topUl = (Aspose.Html.HTMLElement)document.CreateElement("ul");

            // Recursively build list items from XML
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                AddNode(document, topUl, childNode);
            }

            // Insert the generated list into the placeholder div
            var contentDiv = document.GetElementById("content");
            if (contentDiv != null)
            {
                contentDiv.AppendChild(topUl);
            }
            else
            {
                // Fallback: prepend to body
                var body = document.Body;
                var firstChild = body.FirstChild;
                if (firstChild != null)
                    body.InsertBefore(topUl, firstChild);
                else
                    body.AppendChild(topUl);
            }

            // Save the result
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AddNode(Aspose.Html.HTMLDocument doc, Aspose.Html.HTMLElement parentUl, XmlNode xmlNode)
    {
        // Create list item
        var li = (Aspose.Html.HTMLElement)doc.CreateElement("li");

        // Determine display text
        string text = string.Empty;
        if (xmlNode.Attributes != null && xmlNode.Attributes["name"] != null)
        {
            text = xmlNode.Attributes["name"].Value;
        }
        else if (!xmlNode.HasChildNodes || xmlNode.FirstChild is XmlText)
        {
            text = xmlNode.InnerText.Trim();
        }

        li.AppendChild(doc.CreateTextNode(text));

        // Process child elements recursively
        XmlNodeList childElements = xmlNode.SelectNodes("./*");
        if (childElements != null && childElements.Count > 0)
        {
            var nestedUl = (Aspose.Html.HTMLElement)doc.CreateElement("ul");
            foreach (XmlNode child in childElements)
            {
                AddNode(doc, nestedUl, child);
            }
            li.AppendChild(nestedUl);
        }

        parentUl.AppendChild(li);
    }
}