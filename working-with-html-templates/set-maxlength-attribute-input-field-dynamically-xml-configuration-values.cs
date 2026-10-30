// Set the maxlength attribute of an input field dynamically from XML configuration values.

using System;
using System.IO;
using System.Xml.Linq;
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
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><input id=\"myInput\" type=\"text\" /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Prepare sample XML configuration file
            string xmlPath = "config.xml";
            string xmlContent = "<config><maxlength>10</maxlength></config>";
            File.WriteAllText(xmlPath, xmlContent);

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Load XML configuration
            XDocument config = XDocument.Load(xmlPath);
            string maxLengthValue = config.Root.Element("maxlength")?.Value ?? "0";

            // Find the input element and set maxlength attribute
            Element inputElement = document.QuerySelector("#myInput");
            if (inputElement != null)
            {
                inputElement.SetAttribute("maxlength", maxLengthValue);
            }

            // Save the modified HTML
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine("Modified HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}