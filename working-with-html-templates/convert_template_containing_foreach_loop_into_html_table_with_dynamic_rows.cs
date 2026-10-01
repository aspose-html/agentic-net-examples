// Convert a template that contains a foreach loop into an HTML table with dynamic rows.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string outputPath = "output.html";

            // Create a simple template with a foreach loop
            string templateContent = @"
<html>
<body>
<table border='1'>
{{#foreach items}}
<tr><td>{{value}}</td></tr>
{{/foreach}}
</table>
</body>
</html>";
            File.WriteAllText(inputPath, templateContent);

            // JSON data for the template
            string jsonData = @"{ ""items"": [ { ""value"": ""Row 1"" }, { ""value"": ""Row 2"" }, { ""value"": ""Row 3"" } ] }";

            // Prepare template data and options
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to a final HTML document
            Aspose.Html.Converters.Converter.ConvertTemplate(inputPath, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}