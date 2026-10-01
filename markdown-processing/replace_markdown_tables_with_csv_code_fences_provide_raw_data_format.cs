// Replace all Markdown tables with CSV code fences to provide raw data format.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing a table
            string htmlContent = "<html><body><table>" +
                                 "<tr><th>Name</th><th>Age</th></tr>" +
                                 "<tr><td>Alice</td><td>30</td></tr>" +
                                 "<tr><td>Bob</td><td>25</td></tr>" +
                                 "</table></body></html>";

            // Load HTML into Aspose.Html document
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all tables in the document
            var tables = document.GetElementsByTagName("table");

            var csvBuilder = new StringBuilder();

            foreach (Aspose.Html.Dom.Element tableElement in tables)
            {
                var table = (Aspose.Html.HTMLTableElement)tableElement;
                var rows = table.GetElementsByTagName("tr");

                foreach (Aspose.Html.Dom.Element rowElement in rows)
                {
                    var row = (Aspose.Html.HTMLTableRowElement)rowElement;
                    var cells = row.Cells;

                    for (int i = 0; i < cells.Length; i++)
                    {
                        var cell = (Aspose.Html.HTMLTableCellElement)cells[i];
                        csvBuilder.Append(cell.TextContent);
                        if (i < cells.Length - 1)
                            csvBuilder.Append(",");
                    }
                    csvBuilder.AppendLine();
                }
            }

            // Save CSV to file
            string outputPath = "output.csv";
            File.WriteAllText(outputPath, csvBuilder.ToString(), Encoding.UTF8);

            Console.WriteLine($"CSV file has been saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}