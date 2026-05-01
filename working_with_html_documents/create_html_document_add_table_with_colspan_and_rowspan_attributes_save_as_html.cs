// Create an HTML document, add a table with colspan and rowspan attributes, and save as HTML.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("");
            Aspose.Html.HTMLElement body = document.Body;
            Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
            table.Border = "1";
            table.Align = "center";
            table.SetAttribute("width", "50%");
            body.AppendChild(table);

            for (int i = 0; i < 3; i++)
            {
                Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                for (int j = 0; j < 3; j++)
                {
                    Aspose.Html.HTMLTableCellElement cell = (Aspose.Html.HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                    cell.TextContent = $"R{i + 1}C{j + 1}";
                    if (i == 0 && j == 0)
                    {
                        cell.ColSpan = 2;
                    }
                    if (i == 0 && j == 2)
                    {
                        cell.RowSpan = 2;
                    }
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}