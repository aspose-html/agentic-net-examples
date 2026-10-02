// Populate a template with CSV data converted to JSON and display it in an HTML table.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample CSV data
            string csv = "Name,Age,City\nAlice,30,New York\nBob,25,Los Angeles";

            // Convert CSV to JSON
            string json = ConvertCsvToJson(csv);

            // Create HTML template with placeholder {{data}}
            string templateContent = @"<!DOCTYPE html>
<html>
<head><title>CSV to Table</title></head>
<body>
<div id=""tableContainer""></div>
<script type=""text/javascript"">
var data = {{data}};
function generateTable(json) {
  var table = '<table border=""1""><tr>';
  for (var key in json[0]) { table += '<th>' + key + '</th>'; }
  table += '</tr>';
  for (var i = 0; i < json.length; i++) {
    table += '<tr>';
    for (var key in json[i]) { table += '<td>' + json[i][key] + '</td>'; }
    table += '</tr>';
  }
  table += '</table>';
  document.getElementById(''tableContainer'').innerHTML = table;
}
generateTable(data);
</script>
</body>
</html>";

            // Write template to a temporary file
            string templatePath = Path.Combine(Path.GetTempPath(), "template.html");
            File.WriteAllText(templatePath, templateContent, Encoding.UTF8);

            // Prepare template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(json);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting HTML
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath, new HTMLSaveOptions());

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string ConvertCsvToJson(string csv)
    {
        var lines = csv.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2) return "[]";

        var headers = lines[0].Split(',');
        var rows = new List<Dictionary<string, string>>();

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var dict = new Dictionary<string, string>();
            for (int j = 0; j < headers.Length && j < values.Length; j++)
            {
                dict[headers[j]] = values[j];
            }
            rows.Add(dict);
        }

        return JsonSerializer.Serialize(rows);
    }
}