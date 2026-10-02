// Set the selected attribute on option elements based on matching values in the XML data source.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample XML data source
            string xmlContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
    <selectedValue>2</selectedValue>
</root>";
            // Load XML into HTMLDocument (as a generic document)
            Aspose.Html.HTMLDocument xmlDoc = new Aspose.Html.HTMLDocument(xmlContent, "about:blank");

            // Evaluate XPath to get the value to match
            Aspose.Html.Dom.XPath.IXPathResult xpathResult = xmlDoc.Evaluate(
                "//selectedValue",
                xmlDoc,
                xmlDoc.CreateNSResolver(xmlDoc),
                Aspose.Html.Dom.XPath.XPathResultType.String,
                null);
            string selectedValue = xpathResult.StringValue;

            // Sample HTML template with <option> elements
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <select id=""mySelect"">
        <option value=""1"">One</option>
        <option value=""2"">Two</option>
        <option value=""3"">Three</option>
    </select>
</body>
</html>";

            // Load HTML content
            Aspose.Html.HTMLDocument htmlDoc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Iterate over all <option> elements and set the selected attribute
            var options = htmlDoc.GetElementsByTagName("option");
            foreach (var node in options)
            {
                Aspose.Html.HTMLElement option = node as Aspose.Html.HTMLElement;
                if (option != null)
                {
                    string value = option.GetAttribute("value");
                    if (value == selectedValue)
                    {
                        option.SetAttribute("selected", "selected");
                    }
                    else
                    {
                        option.RemoveAttribute("selected");
                    }
                }
            }

            // Save the modified HTML to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            htmlDoc.Save(outputPath);

            Console.WriteLine("HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}