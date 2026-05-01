// Set the selected attribute on option elements based on matching values in the XML data source.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main()
    {
        try
        {
            // Load XML data source
            HTMLDocument xmlDoc = new HTMLDocument("data.xml");

            // Evaluate XPath to select option values from XML
            IXPathResult xmlResult = xmlDoc.Evaluate("//OptionValue", xmlDoc, xmlDoc.CreateNSResolver(xmlDoc), XPathResultType.Any, null);

            // Collect values into a set for quick lookup
            var valueSet = new HashSet<string>();
            Node xmlNode;
            while ((xmlNode = xmlResult.IterateNext()) != null)
            {
                if (!string.IsNullOrEmpty(xmlNode.TextContent))
                    valueSet.Add(xmlNode.TextContent.Trim());
            }

            // Load HTML template containing <select><option> elements
            HTMLDocument htmlDoc = new HTMLDocument("template.html");

            // Get all option elements
            var optionElements = htmlDoc.GetElementsByTagName("option");
            foreach (var elem in optionElements)
            {
                var option = elem as Aspose.Html.HTMLOptionElement;
                if (option != null && valueSet.Contains(option.Value))
                {
                    option.Selected = true;
                }
            }

            // Save the modified HTML document
            htmlDoc.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}