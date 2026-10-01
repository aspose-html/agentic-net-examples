// Set the disabled attribute on form inputs conditionally based on values in the XML data.

using System;
using System.IO;
using System.Xml;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html><html><body><form><input type='text' name='firstName' /><input type='text' name='lastName' /><input type='checkbox' name='subscribe' /></form></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Prepare sample XML data file
            string xmlPath = "data.xml";
            string xmlContent = @"<root><field name='firstName'>true</field><field name='subscribe'>false</field></root>";
            File.WriteAllText(xmlPath, xmlContent);

            // Load XML data
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Select all input elements
            var inputs = document.QuerySelectorAll("input");

            // Iterate over inputs and set or remove the disabled attribute based on XML data
            for (int i = 0; i < inputs.Length; i++)
            {
                Element element = (Element)inputs[i];
                string name = element.GetAttribute("name");
                if (!string.IsNullOrEmpty(name))
                {
                    XmlNode node = xmlDoc.SelectSingleNode($"/root/field[@name='{name}']");
                    bool shouldDisable = node != null && node.InnerText.Equals("true", StringComparison.OrdinalIgnoreCase);
                    if (shouldDisable)
                    {
                        element.SetAttribute("disabled", "disabled");
                    }
                    else
                    {
                        element.RemoveAttribute("disabled");
                    }
                }
            }

            // Save the modified HTML
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}