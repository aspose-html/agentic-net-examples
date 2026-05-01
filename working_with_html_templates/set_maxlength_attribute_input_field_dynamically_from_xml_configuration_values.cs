// Set the maxlength attribute of an input field dynamically from XML configuration values.

using System;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string xmlPath = "config.xml";
            string outputPath = "output.html";

            // Load configuration XML and retrieve maxlength value
            XDocument configDoc = XDocument.Load(xmlPath);
            string maxLengthValue = configDoc.Root.Element("maxlength")?.Value ?? "0";

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Find the first input element
            Element inputElement = document.QuerySelector("input");
            if (inputElement != null)
            {
                // Set the maxlength attribute dynamically
                inputElement.SetAttribute("maxlength", maxLengthValue);
            }

            // Save the modified HTML document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}