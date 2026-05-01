// Load an HTML file, extract all table elements, and write each table to separate HTML files.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace ExtractTablesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";

                // Load the source HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Get all table elements
                HTMLCollection tables = document.GetElementsByTagName("table");

                // Iterate over each table and save it to a separate file
                for (int i = 0; i < tables.Length; i++)
                {
                    HTMLElement tableElement = tables[i] as HTMLElement;
                    if (tableElement == null)
                        continue;

                    string tableHtml = tableElement.OuterHTML;
                    string outputPath = $"table{i}.html";

                    // Create a new document containing only the table HTML
                    HTMLDocument tableDoc = new HTMLDocument(tableHtml, "");

                    // Save the table document
                    tableDoc.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}