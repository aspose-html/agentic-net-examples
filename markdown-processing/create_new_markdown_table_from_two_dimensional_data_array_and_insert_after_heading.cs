// Create a new Markdown table from a two‑dimensional data array and insert it after a heading.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = document.Body;

            Aspose.Html.HTMLHeadingElement heading = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            heading.AppendChild(document.CreateTextNode("Sample Heading"));
            body.AppendChild(heading);

            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("width", "50%");

            string[,] data = new string[,]
            {
                { "Header1", "Header2", "Header3" },
                { "Row1Col1", "Row1Col2", "Row1Col3" },
                { "Row2Col1", "Row2Col2", "Row2Col3" }
            };

            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < cols; j++)
                {
                    Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = data[i, j];
                }
            }

            body.AppendChild(table);
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}