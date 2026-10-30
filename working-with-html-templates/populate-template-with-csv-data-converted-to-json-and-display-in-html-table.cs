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
            // Prepare sample CSV data
            string csvContent = "Name,Age\nAlice,30\nBob,25";

            // Convert CSV to JSON
            string jsonData = ConvertCsvToJson(csvContent);

            // Create a simple HTML template with placeholders
            string templateHtml = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>CSV to HTML Table</title>
</head>
<body>
    <h2>Data Table</h2>
    <table border=""1"">
        <thead>
            <tr><th>Name</th><th>Age</th></tr>
        </thead>
        <tbody>
            {{#each data}}
            <tr><td>{{Name}}</td><td>{{Age}}</td></tr>
            {{/each}}
        </tbody>
    </table>
</body>
</html>";

            // Write template to a file
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "template.html");
            File.WriteAllText(templatePath, templateHtml, Encoding.UTF8);

            // Prepare template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template with data to an HTML document
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting HTML
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            resultDocument.Save(outputPath, new Aspose.Html.Saving.HTMLSaveOptions());

            Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ConvertCsvToJson(string csv)
    {
        var lines = csv.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
            return "[]";

        var headers = lines[0].Split(',');

        var records = new List<Dictionary<string, string>>();
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var dict = new Dictionary<string, string>();
            for (int j = 0; j < headers.Length && j < values.Length; j++)
            {
                dict[headers[j].Trim()] = values[j].Trim();
            }
            records.Add(dict);
        }

        // Wrap records in an object with a "data" property to match template expectation
        var wrapper = new Dictionary<string, object> { { "data", records } };
        return JsonSerializer.Serialize(wrapper);
    }
}