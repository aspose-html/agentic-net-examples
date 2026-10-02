// Convert an HTML table into a JSON array preserving column headers as object keys.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><table><tr><th>Name</th><th>Age</th></tr><tr><td>Alice</td><td>30</td></tr><tr><td>Bob</td><td>25</td></tr></table></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
            var jsonArray = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>();
            foreach (var tableNode in tables)
            {
                if (tableNode is Aspose.Html.HTMLTableElement table)
                {
                    Aspose.Html.Collections.HTMLCollection rows = table.GetElementsByTagName("tr");
                    System.Collections.Generic.List<string> headers = null;
                    foreach (var rowNode in rows)
                    {
                        if (rowNode is Aspose.Html.HTMLTableRowElement row)
                        {
                            Aspose.Html.Collections.HTMLCollection cells = row.Cells;
                            if (headers == null)
                            {
                                headers = new System.Collections.Generic.List<string>();
                                foreach (var cell in cells)
                                {
                                    string headerText = cell.TextContent?.Trim() ?? "";
                                    headers.Add(headerText);
                                }
                            }
                            else
                            {
                                var dict = new System.Collections.Generic.Dictionary<string, string>();
                                int index = 0;
                                foreach (var cell in cells)
                                {
                                    string cellText = cell.TextContent?.Trim() ?? "";
                                    string key = index < headers.Count ? headers[index] : $"Column{index}";
                                    dict[key] = cellText;
                                    index++;
                                }
                                jsonArray.Add(dict);
                            }
                        }
                    }
                }
            }
            string json = System.Text.Json.JsonSerializer.Serialize(jsonArray, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            string outputPath = "output.json";
            System.IO.File.WriteAllText(outputPath, json);
            System.Console.WriteLine($"JSON saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}