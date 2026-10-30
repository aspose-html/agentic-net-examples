// Create an HTML document, embed a data table using JSON data, and export to HTML.

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
            // Prepare JSON data file
            string jsonPath = "data.json";
            string jsonContent = @"[
    { ""Name"": ""Alice"", ""Age"": 30 },
    { ""Name"": ""Bob"", ""Age"": 25 },
    { ""Name"": ""Charlie"", ""Age"": 28 }
]";
            File.WriteAllText(jsonPath, jsonContent);

            // Prepare HTML template file
            string templatePath = "template.html";
            string templateContent = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Data Table</title>
</head>
<body>
    <h1>People</h1>
    <table border=""1"">
        <thead>
            <tr><th>Name</th><th>Age</th></tr>
        </thead>
        <tbody>
            {{#each this}}
            <tr><td>{{Name}}</td><td>{{Age}}</td></tr>
            {{/each}}
        </tbody>
    </table>
</body>
</html>";
            File.WriteAllText(templatePath, templateContent);

            // Load JSON data as template data
            TemplateData templateData = new TemplateData(jsonPath);

            // Load options (default)
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Output HTML file
            string outputPath = "output.html";

            // Perform template conversion
            Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);

            Console.WriteLine($"HTML document generated at: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}