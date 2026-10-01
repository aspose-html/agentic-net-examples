// Extract table data from HTML tables and export each table to a separate CSV file.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                "<table><tr><td>Header1</td><td>Header2</td></tr><tr><td>Row1Col1</td><td>Row1Col2</td></tr></table>" +
                "<table><tr><td>A</td><td>B</td></tr><tr><td>C</td><td>D</td></tr></table>" +
                "</body></html>";

            var document = new Aspose.Html.HTMLDocument(html);
            var tables = document.GetElementsByTagName("table");
            int tableIndex = 1;
            foreach (var tableNode in tables)
            {
                if (tableNode is Aspose.Html.HTMLTableElement table)
                {
                    var sb = new System.Text.StringBuilder();
                    var rows = table.GetElementsByTagName("tr");
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is Aspose.Html.HTMLTableRowElement row)
                        {
                            var cells = row.Cells;
                            bool firstCell = true;
                            foreach (var cell in cells)
                            {
                                string cellText = cell.TextContent?.Trim();
                                if (cellText != null && cellText.Contains("\""))
                                {
                                    cellText = cellText.Replace("\"", "\"\"");
                                }
                                if (cellText != null && (cellText.Contains(",") || cellText.Contains("\"")))
                                {
                                    cellText = $"\"{cellText}\"";
                                }
                                if (!firstCell) sb.Append(",");
                                sb.Append(cellText);
                                firstCell = false;
                            }
                            sb.AppendLine();
                        }
                    }
                    string fileName = $"table_{tableIndex}.csv";
                    System.IO.File.WriteAllText(fileName, sb.ToString());
                    System.Console.WriteLine($"Table {tableIndex} saved to {fileName}");
                    tableIndex++;
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}