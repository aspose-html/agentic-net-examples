// Replace all Markdown tables with CSV code fences to provide raw data format.

namespace AsposeHtmlTableToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><table><tr><th>Name</th><th>Age</th></tr><tr><td>Alice</td><td>30</td></tr><tr><td>Bob</td><td>25</td></tr></table></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
                for (int i = 0; i < tables.Length; i++)
                {
                    Aspose.Html.Dom.Element table = (Aspose.Html.Dom.Element)tables[i];
                    Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                    System.Text.StringBuilder csvBuilder = new System.Text.StringBuilder();
                    for (int r = 0; r < rows.Length; r++)
                    {
                        Aspose.Html.Dom.Element row = (Aspose.Html.Dom.Element)rows[r];
                        Aspose.Html.Collections.HTMLCollection cells = row.GetElementsByTagName("th");
                        if (cells.Length == 0)
                        {
                            cells = row.GetElementsByTagName("td");
                        }
                        for (int c = 0; c < cells.Length; c++)
                        {
                            Aspose.Html.Dom.Element cell = (Aspose.Html.Dom.Element)cells[c];
                            string text = cell.TextContent;
                            if (text.Contains("\"") || text.Contains(",") || text.Contains("\n"))
                            {
                                text = "\"" + text.Replace("\"", "\"\"") + "\"";
                            }
                            csvBuilder.Append(text);
                            if (c < cells.Length - 1)
                                csvBuilder.Append(",");
                        }
                        csvBuilder.AppendLine();
                    }
                    string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), $"table{i + 1}.csv");
                    System.IO.File.WriteAllText(outputPath, csvBuilder.ToString());
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}