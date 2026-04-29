// Replace all Markdown tables with CSV code fences to provide raw data format.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML document containing markdown tables
            string url = "https://example.com/page.html";
            // Path where the modified HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(url);

            // Get all table elements
            HTMLCollection tables = document.GetElementsByTagName("table");

            // Iterate over each table
            for (int t = 0; t < tables.Length; t++)
            {
                HTMLTableElement table = (HTMLTableElement)tables[t];

                // Get all rows of the current table
                HTMLCollection rows = table.GetElementsByTagName("tr");
                StringBuilder csvBuilder = new StringBuilder();

                // Build CSV content from rows and cells
                for (int r = 0; r < rows.Length; r++)
                {
                    HTMLTableRowElement row = (HTMLTableRowElement)rows[r];
                    HTMLCollection cells = row.Cells;

                    for (int c = 0; c < cells.Length; c++)
                    {
                        HTMLTableCellElement cell = (HTMLTableCellElement)cells[c];
                        string text = cell.TextContent.Trim().Replace("\"", "\"\"");
                        csvBuilder.Append('\"').Append(text).Append('\"');

                        if (c < cells.Length - 1)
                            csvBuilder.Append(',');
                    }
                    csvBuilder.AppendLine();
                }

                // Create <pre><code class="language-csv">...</code></pre> element
                HTMLElement pre = (HTMLElement)document.CreateElement("pre");
                HTMLElement code = (HTMLElement)document.CreateElement("code");
                code.SetAttribute("class", "language-csv");
                code.TextContent = csvBuilder.ToString();
                pre.AppendChild(code);

                // Replace the original table with the CSV code fence
                Node parent = table.ParentNode;
                parent.ReplaceChild(pre, table);
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}