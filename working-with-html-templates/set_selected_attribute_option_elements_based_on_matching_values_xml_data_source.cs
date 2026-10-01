// Set the selected attribute on option elements based on matching values in the XML data source.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string xmlPath = "data.xml";
            string htmlPath = "template.html";
            string outputPath = "output.html";

            if (!File.Exists(xmlPath))
            {
                File.WriteAllText(xmlPath, "<Values><Value>1</Value><Value>2</Value></Values>");
            }

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath,
                    "<html><body><select id=\"mySelect\">" +
                    "<option value=\"1\">One</option>" +
                    "<option value=\"2\">Two</option>" +
                    "<option value=\"3\">Three</option>" +
                    "</select></body></html>");
            }

            HTMLDocument xmlDoc = new HTMLDocument(xmlPath);
            HTMLDocument htmlDoc = new HTMLDocument(htmlPath);

            IXPathResult valueResult = xmlDoc.Evaluate("//Value", xmlDoc, xmlDoc.CreateNSResolver(xmlDoc), XPathResultType.Any, null);
            HashSet<string> validValues = new HashSet<string>();
            Node valueNode;
            while ((valueNode = valueResult.IterateNext()) != null)
            {
                if (!string.IsNullOrEmpty(valueNode.TextContent))
                {
                    validValues.Add(valueNode.TextContent.Trim());
                }
            }

            var optionNodes = htmlDoc.GetElementsByTagName("option");
            foreach (Node optNode in optionNodes)
            {
                var option = (Aspose.Html.HTMLOptionElement)optNode;
                if (validValues.Contains(option.Value))
                {
                    option.Selected = true;
                }
            }

            htmlDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}