// Create a new Markdown table from a two‑dimensional data array and insert it after a heading.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            var doc = new Aspose.Html.HTMLDocument();
            var body = doc.Body;

            // Add a heading
            var heading = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            heading.SetAttribute("id", "title");
            heading.AppendChild(doc.CreateTextNode("Sample Table"));
            body.AppendChild(heading);

            // Two‑dimensional data array
            string[,] data = new string[,]
            {
                { "Name", "Age", "City" },
                { "Alice", "30", "New York" },
                { "Bob", "25", "London" },
                { "Charlie", "35", "Paris" }
            };

            // Create a table element
            var table = (Aspose.Html.HTMLTableElement)doc.CreateElement("table");
            table.Border = "1";
            table.Align = "center";

            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            // Populate the table
            for (int i = 0; i < rows; i++)
            {
                var row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < cols; j++)
                {
                    var cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = data[i, j];
                }
            }

            // Insert the table after the heading
            body.AppendChild(table);

            // Save the document
            string outputPath = "output.html";
            doc.Save(outputPath);
            Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}