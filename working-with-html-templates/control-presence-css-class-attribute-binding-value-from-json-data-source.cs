// Control the presence of a CSS class attribute by binding its value from the JSON data source.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with data-id attributes
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <style>
        .red { color: red; }
    </style>
</head>
<body>
    <div data-id=""1"">Item 1</div>
    <div data-id=""2"">Item 2</div>
    <div data-id=""3"">Item 3</div>
</body>
</html>";

            // Sample JSON mapping data-id to CSS class name
            string jsonContent = @"{ ""1"": ""red"", ""3"": ""red"" }";

            // Parse JSON into a dictionary
            Dictionary<string, string> classMap = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            // Load HTML document from string (using two-argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all elements that have a data-id attribute
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[data-id]");

            // Bind CSS class attribute based on JSON data
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string id = element.GetAttribute("data-id");
                if (id != null && classMap != null && classMap.TryGetValue(id, out string className))
                {
                    element.SetAttribute("class", className);
                }
                else
                {
                    element.RemoveAttribute("class");
                }
            }

            // Save the modified HTML to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}