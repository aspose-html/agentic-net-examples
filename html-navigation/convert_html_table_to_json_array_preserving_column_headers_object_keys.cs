// Convert an HTML table into a JSON array preserving column headers as object keys.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with a table
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                 "<table>" +
                                 "<tr><th>Name</th><th>Age</th><th>City</th></tr>" +
                                 "<tr><td>Alice</td><td>30</td><td>New York</td></tr>" +
                                 "<tr><td>Bob</td><td>25</td><td>London</td></tr>" +
                                 "</table>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all tables
            HTMLCollection tables = document.GetElementsByTagName("table");
            var jsonArray = new List<Dictionary<string, string>>();

            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    // Get all rows
                    HTMLCollection rows = table.GetElementsByTagName("tr");
                    List<string> headers = null;

                    foreach (var rowNode in rows)
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            HTMLCollection cells = row.Cells;
                            List<string> cellTexts = new List<string>();
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim();
                                cellTexts.Add(cellText);
                            }

                            // First row assumed as header
                            if (headers == null)
                            {
                                headers = cellTexts;
                            }
                            else
                            {
                                var obj = new Dictionary<string, string>();
                                for (int i = 0; i < headers.Count && i < cellTexts.Count; i++)
                                {
                                    obj[headers[i]] = cellTexts[i];
                                }
                                jsonArray.Add(obj);
                            }
                        }
                    }
                }
            }

            // Serialize to JSON
            string jsonOutput = JsonSerializer.Serialize(jsonArray, new JsonSerializerOptions { WriteIndented = true });
            string jsonPath = "output.json";
            File.WriteAllText(jsonPath, jsonOutput, Encoding.UTF8);

            Console.WriteLine("JSON conversion completed. Output written to " + jsonPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}