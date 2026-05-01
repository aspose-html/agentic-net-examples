// Control the presence of a CSS class attribute by binding its value from the JSON data source.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            string jsonContent = File.ReadAllText(jsonPath);
            var classMap = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            foreach (var kvp in classMap)
            {
                var element = document.QuerySelector($"#{kvp.Key}") as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    element.ClassName = kvp.Value ?? string.Empty;
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}