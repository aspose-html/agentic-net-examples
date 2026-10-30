// Use TemplateData to bind a list of products from JSON and generate a repeating product card layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML template with a repeating product card layout
            string templatePath = "template.html";
            string templateContent = @"
<html>
<head>
    <style>
        .card { border: 1px solid #ccc; padding: 10px; margin: 5px; }
    </style>
</head>
<body>
    <h1>Product List</h1>
    {{#each products}}
    <div class=""card"">
        <h2>{{Name}}</h2>
        <p>Price: ${{Price}}</p>
    </div>
    {{/each}}
</body>
</html>";
            File.WriteAllText(templatePath, templateContent);

            // Create a JSON file containing a list of products
            string jsonPath = "products.json";
            string jsonContent = @"[
    { ""Name"": ""Product 1"", ""Price"": 10.0 },
    { ""Name"": ""Product 2"", ""Price"": 20.0 },
    { ""Name"": ""Product 3"", ""Price"": 30.0 }
]";
            File.WriteAllText(jsonPath, jsonContent);

            // Load template data from the JSON file
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template using the data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);

            // Save the resulting HTML
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}