// Populate a template with CSV data converted to JSON and display it in an HTML table.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Create a simple HTML template with a placeholder for the JSON data
            string templateContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>CSV to JSON Table</title>
</head>
<body>
    <h1>Data Table</h1>
    <!-- Aspose HTML templating placeholder -->
    {{#each rows}}
    <tr>
        {{#each this}}
        <td>{{this}}</td>
        {{/each}}
    </tr>
    {{/each}}
    <table border=""1"">
        <thead>
            <tr>
                {{#each headers}}
                <th>{{this}}</th>
                {{/each}}
            </tr>
        </thead>
        <tbody>
            {{#each rows}}
            <tr>
                {{#each this}}
                <td>{{this}}</td>
                {{/each}}
            </tr>
            {{/each}}
        </tbody>
    </table>
</body>
</html>";
            File.WriteAllText(templatePath, templateContent, Encoding.UTF8);

            // Sample CSV data
            string csvData = @"Name,Age,Country
Alice,30,USA
Bob,25,Canada
Charlie,28,UK";

            // Convert CSV to JSON
            string jsonData = ConvertCsvToJson(csvData);
            File.WriteAllText(jsonPath, jsonData, Encoding.UTF8);

            // Prepare template data and load options
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template with JSON data to an HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting HTML
            document.Save(outputPath);

            Console.WriteLine("HTML file generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Helper method to convert CSV string to JSON string
    static string ConvertCsvToJson(string csv)
    {
        var lines = csv.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
            throw new InvalidOperationException("CSV must contain header and at least one data row.");

        var headers = lines[0].Split(',');

        var rows = new List<Dictionary<string, string>>();
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var row = new Dictionary<string, string>();
            for (int j = 0; j < headers.Length && j < values.Length; j++)
            {
                row[headers[j]] = values[j];
            }
            rows.Add(row);
        }

        var jsonObject = new
        {
            headers = headers,
            rows = rows
        };

        return JsonSerializer.Serialize(jsonObject);
    }
}