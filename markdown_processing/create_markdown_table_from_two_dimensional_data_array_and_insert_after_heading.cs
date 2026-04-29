// Create a new Markdown table from a two‑dimensional data array and insert it after a heading.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new empty HTML document
            HTMLDocument document = new HTMLDocument();
            HTMLElement body = document.Body;

            // Create a heading element (h1) and add text
            HTMLHeadingElement h1 = (HTMLHeadingElement)document.CreateElement("h1");
            Text headingText = document.CreateTextNode("Data Table");
            h1.AppendChild(headingText);
            body.AppendChild(h1);

            // Create a table element
            HTMLTableElement table = (HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("width", "50%");

            // Sample two‑dimensional data array
            string[,] data = new string[,]
            {
                { "Header1", "Header2", "Header3" },
                { "Row1Col1", "Row1Col2", "Row1Col3" },
                { "Row2Col1", "Row2Col2", "Row2Col3" }
            };

            // Populate the table with rows and cells
            for (int i = 0; i < data.GetLength(0); i++)
            {
                HTMLTableRowElement row = (HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    HTMLTableCellElement cell = (HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = data[i, j];
                }
            }

            // Append the table after the heading
            body.AppendChild(table);

            // Convert the HTML document to Markdown and save
            MarkdownSaveOptions mdOptions = new MarkdownSaveOptions();
            Converter.ConvertHTML(document, mdOptions, "output.md");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}