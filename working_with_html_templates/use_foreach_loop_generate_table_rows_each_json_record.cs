// Use a foreach loop to generate table rows for each record in a JSON dataset.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Dom;

namespace AsposeHtmlJsonTable
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load JSON data from a file
                string jsonPath = "data.json";
                string jsonContent = File.ReadAllText(jsonPath);
                var records = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonContent);

                // Create an empty HTML document
                HTMLDocument document = new HTMLDocument();

                // Create a table element and add it to the body
                HTMLElement table = (HTMLElement)document.CreateElement("table");
                document.Body.AppendChild(table);

                // Generate table rows for each record
                foreach (var record in records)
                {
                    HTMLElement row = (HTMLElement)document.CreateElement("tr");
                    foreach (var kvp in record)
                    {
                        HTMLElement cell = (HTMLElement)document.CreateElement("td");
                        cell.TextContent = kvp.Value;
                        row.AppendChild(cell);
                    }
                    table.AppendChild(row);
                }

                // Save the resulting HTML to a file
                string outputPath = "output.html";
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}