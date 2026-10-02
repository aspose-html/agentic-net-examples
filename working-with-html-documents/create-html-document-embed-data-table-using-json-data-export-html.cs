// Create an HTML document, embed a data table using JSON data, and export to HTML.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string templatePath = System.IO.Path.Combine(baseDir, "template.html");
            string jsonPath = System.IO.Path.Combine(baseDir, "data.json");
            string outputPath = System.IO.Path.Combine(baseDir, "output.html");

            string templateContent = "<!DOCTYPE html><html><head><title>Data Table</title></head><body><h1>Data Table</h1><table border='1'><thead><tr><th>Name</th><th>Value</th></tr></thead><tbody>{{#items}}<tr><td>{{name}}</td><td>{{value}}</td></tr>{{/items}}</tbody></table></body></html>";
            System.IO.File.WriteAllText(templatePath, templateContent);

            string jsonContent = "{\"items\":[{\"name\":\"Item1\",\"value\":10},{\"name\":\"Item2\",\"value\":20},{\"name\":\"Item3\",\"value\":30}]}";
            System.IO.File.WriteAllText(jsonPath, jsonContent);

            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options);
            document.Save(outputPath);

            Console.WriteLine("HTML document generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}