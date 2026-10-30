// Set the disabled attribute on form inputs conditionally based on values in the XML data.

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define file paths
                string inputHtmlPath = "sample.html";
                string inputXmlPath = "data.xml";
                string outputHtmlPath = "output.html";

                // Create a minimal HTML file if it does not exist
                if (!File.Exists(inputHtmlPath))
                {
                    File.WriteAllText(inputHtmlPath,
                        "<!DOCTYPE html><html><body><form>" +
                        "<input id=\"first\" type=\"text\" />" +
                        "<input id=\"second\" type=\"text\" />" +
                        "</form></body></html>");
                }

                // Create a minimal XML file if it does not exist
                if (!File.Exists(inputXmlPath))
                {
                    File.WriteAllText(inputXmlPath,
                        "<inputs>" +
                        "<input id=\"first\" disabled=\"true\" />" +
                        "<input id=\"second\" disabled=\"false\" />" +
                        "</inputs>");
                }

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

                // Load the XML data
                XDocument xmlDoc = XDocument.Load(inputXmlPath);

                // Get all input elements in the HTML
                Aspose.Html.Collections.HTMLCollection inputs = document.GetElementsByTagName("input");

                for (int i = 0; i < inputs.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)inputs[i];
                    string id = element.GetAttribute("id");
                    if (string.IsNullOrEmpty(id))
                        continue;

                    // Find matching XML element by id
                    var xmlInput = xmlDoc.Root
                        .Elements("input")
                        .FirstOrDefault(x => (string)x.Attribute("id") == id);

                    if (xmlInput != null)
                    {
                        string disabledAttr = (string)xmlInput.Attribute("disabled");
                        if (!string.IsNullOrEmpty(disabledAttr) &&
                            disabledAttr.Equals("true", StringComparison.OrdinalIgnoreCase))
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
                document.Save(outputHtmlPath);
                Console.WriteLine("Processing completed. Output saved to " + outputHtmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}