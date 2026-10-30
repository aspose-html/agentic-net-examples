// Convert a template that contains a foreach loop into an HTML table with dynamic rows.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string templatePath = "template.html";
            string outputPath = "output.html";

            // Create a simple HTML template with a foreach loop placeholder
            string templateContent = @"
<html>
<body>
<table border='1' align='center'>
<thead><tr><th>Item</th></tr></thead>
<tbody>
{{#foreach items}}
<tr><td>{{this}}</td></tr>
{{/foreach}}
</tbody>
</table>
</body>
</html>";
            File.WriteAllText(templatePath, templateContent);

            // Prepare template data (JSON format)
            string jsonData = @"{ ""items"": [""Apple"", ""Banana"", ""Cherry""] }";
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to a final HTML document
            Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options, outputPath);

            Console.WriteLine($"Template converted successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}