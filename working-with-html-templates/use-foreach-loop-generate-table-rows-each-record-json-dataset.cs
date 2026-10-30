// Use a foreach loop to generate table rows for each record in a JSON dataset.

using System;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample JSON dataset
            string json = "[{\"Name\":\"Alice\",\"Age\":30},{\"Name\":\"Bob\",\"Age\":25}]";

            // Parse JSON
            using JsonDocument jsonDoc = JsonDocument.Parse(json);
            JsonElement root = jsonDoc.RootElement;

            // Create an empty HTML document
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body></body></html>", "about:blank");

            // Create a table element and add it to the body
            Aspose.Html.HTMLElement table = (Aspose.Html.HTMLElement)document.CreateElement("table");
            document.Body.AppendChild(table);

            // Generate table rows for each record in the JSON array
            foreach (JsonElement record in root.EnumerateArray())
            {
                Aspose.Html.HTMLElement row = (Aspose.Html.HTMLElement)document.CreateElement("tr");
                table.AppendChild(row);

                foreach (JsonProperty property in record.EnumerateObject())
                {
                    Aspose.Html.HTMLElement cell = (Aspose.Html.HTMLElement)document.CreateElement("td");
                    string cellText = property.Value.ValueKind == JsonValueKind.String
                        ? property.Value.GetString()
                        : property.Value.ToString();
                    cell.TextContent = cellText;
                    row.AppendChild(cell);
                }
            }

            // Save the resulting HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath, new Aspose.Html.Saving.HTMLSaveOptions());

            Console.WriteLine($"HTML document generated and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}