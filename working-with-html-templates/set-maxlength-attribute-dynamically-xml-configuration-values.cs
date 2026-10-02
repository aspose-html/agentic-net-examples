// Set the maxlength attribute of an input field dynamically from XML configuration values.

using System;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an input element
            string htmlContent = "<!DOCTYPE html><html><body><input id='myInput' type='text' /></body></html>";

            // Load HTML document from string (base URI is required)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Sample XML configuration containing maxlength value
            string xmlContent = "<config><input maxlength='20'/></config>";
            XDocument xmlDoc = XDocument.Parse(xmlContent);
            string maxLength = (string)xmlDoc.Root.Element("input")?.Attribute("maxlength") ?? "0";

            // Find the input element and set its maxlength attribute
            Aspose.Html.Dom.Element inputElement = document.QuerySelector("#myInput");
            inputElement.SetAttribute("maxlength", maxLength);

            // Save the modified HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}' with maxlength={maxLength}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}