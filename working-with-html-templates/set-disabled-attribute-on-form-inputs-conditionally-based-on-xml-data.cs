// Set the disabled attribute on form inputs conditionally based on values in the XML data.

using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string inputXmlPath = "data.xml";
            string outputHtmlPath = "output.html";

            if (!File.Exists(inputHtmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><form>" +
                                     "<input type=\"text\" name=\"firstName\"/>" +
                                     "<input type=\"text\" name=\"age\"/>" +
                                     "<input type=\"checkbox\" name=\"subscribe\"/>" +
                                     "</form></body></html>";
                File.WriteAllText(inputHtmlPath, htmlContent);
            }

            if (!File.Exists(inputXmlPath))
            {
                string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                    "<data>" +
                                    "<field name=\"firstName\" disabled=\"true\"/>" +
                                    "<field name=\"age\" disabled=\"false\"/>" +
                                    "<field name=\"subscribe\" disabled=\"true\"/>" +
                                    "</data>";
                File.WriteAllText(inputXmlPath, xmlContent);
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(inputXmlPath);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            var inputs = document.QuerySelectorAll("input");
            for (int i = 0; i < inputs.Length; i++)
            {
                Aspose.Html.Dom.Element el = (Aspose.Html.Dom.Element)inputs[i];
                string name = el.GetAttribute("name");
                if (string.IsNullOrEmpty(name))
                    continue;

                XmlNode fieldNode = xmlDoc.SelectSingleNode($"/data/field[@name='{name}']");
                if (fieldNode != null)
                {
                    string disabledValue = fieldNode.Attributes["disabled"]?.Value;
                    if (!string.IsNullOrEmpty(disabledValue) && disabledValue.Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        el.SetAttribute("disabled", "disabled");
                    }
                    else
                    {
                        el.RemoveAttribute("disabled");
                    }
                }
            }

            document.Save(outputHtmlPath);
            Console.WriteLine("Modified HTML saved to " + outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}