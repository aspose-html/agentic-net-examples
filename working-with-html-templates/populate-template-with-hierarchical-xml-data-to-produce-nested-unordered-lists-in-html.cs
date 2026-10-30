// Populate a template with hierarchical XML data to produce nested unordered lists in HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputFolder = "Input";
            string outputFolder = "Output";
            string xmlPath = Path.Combine(inputFolder, "data.xml");
            string templatePath = Path.Combine(inputFolder, "template.html");
            string resultPath = Path.Combine(outputFolder, "result.html");

            // Ensure folders exist
            if (!Directory.Exists(inputFolder)) Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

            // Create sample XML data if not present
            if (!File.Exists(xmlPath))
            {
                string xmlContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
  <category name=""Fruits"">
    <item name=""Apple"" />
    <item name=""Banana"" />
  </category>
  <category name=""Vegetables"">
    <item name=""Carrot"" />
    <item name=""Lettuce"" />
  </category>
</root>";
                File.WriteAllText(xmlPath, xmlContent);
            }

            // Create sample HTML template if not present
            if (!File.Exists(templatePath))
            {
                string templateContent = @"<!DOCTYPE html>
<html>
<head><title>Sample List</title></head>
<body>
<h1>Products</h1>
<ul data-repeat=""category"">
  <li>
    <strong>{{category/@name}}</strong>
    <ul data-repeat=""item"">
      <li>{{item/@name}}</li>
    </ul>
  </li>
</ul>
</body>
</html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Load template document
            var document = new Aspose.Html.HTMLDocument(templatePath, new Aspose.Html.Configuration());

            // Load hierarchical XML data
            var templateData = new Aspose.Html.Converters.TemplateData(xmlPath);

            // Template load options (default)
            var options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options, resultPath);

            Console.WriteLine($"Template conversion completed. Result saved to: {resultPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}