// Set the disabled attribute on form inputs conditionally based on values in the XML data.

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Forms;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the HTML file, XML data file and the output HTML file
            string htmlPath = "input.html";
            string xmlPath = "data.xml";
            string outputPath = "output.html";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Load the XML data
                XDocument xmlDoc = XDocument.Load(xmlPath);

                // Select all input elements in the document
                var inputs = document.QuerySelectorAll("input");

                for (int i = 0; i < inputs.Length; i++)
                {
                    // Cast the node to HTMLInputElement
                    HTMLInputElement input = inputs[i] as HTMLInputElement;
                    if (input == null) continue;

                    // Get the name attribute of the input element
                    string name = input.GetAttribute("name");
                    if (string.IsNullOrEmpty(name)) continue;

                    // Find the corresponding XML element (e.g., <field name="username" disabled="true"/>)
                    var xmlElement = xmlDoc.Root
                        .Elements()
                        .FirstOrDefault(e => (string)e.Attribute("name") == name);

                    if (xmlElement != null)
                    {
                        // Read the disabled attribute from XML (true/false)
                        bool disabled = false;
                        var disabledAttr = xmlElement.Attribute("disabled");
                        if (disabledAttr != null)
                        {
                            bool.TryParse(disabledAttr.Value, out disabled);
                        }

                        // Set the Disabled property on the input element
                        input.Disabled = disabled;
                    }
                }

                // Save the modified HTML document
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}