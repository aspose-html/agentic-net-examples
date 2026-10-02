// Use a foreach loop to generate table rows for each record in a JSON dataset.

class Program
{
    static void Main()
    {
        try
        {
            // JSON dataset
            string json = "[{\"Name\":\"Alice\",\"Age\":30},{\"Name\":\"Bob\",\"Age\":25}]";

            // Parse JSON
            using (System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(json))
            {
                System.Text.Json.JsonElement root = doc.RootElement;

                // Create an HTML document with inline content
                string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"/></head><body></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    // Create a table element and add it to the body
                    Aspose.Html.HTMLTableElement table = (Aspose.Html.HTMLTableElement)document.CreateElement("table");
                    document.Body.AppendChild(table);

                    // Generate table rows for each record in the JSON dataset
                    foreach (System.Text.Json.JsonElement record in root.EnumerateArray())
                    {
                        Aspose.Html.HTMLTableRowElement row = (Aspose.Html.HTMLTableRowElement)document.CreateElement("tr");

                        // Name cell
                        Aspose.Html.HTMLTableCellElement nameCell = (Aspose.Html.HTMLTableCellElement)document.CreateElement("td");
                        nameCell.TextContent = record.GetProperty("Name").GetString();
                        row.AppendChild(nameCell);

                        // Age cell
                        Aspose.Html.HTMLTableCellElement ageCell = (Aspose.Html.HTMLTableCellElement)document.CreateElement("td");
                        ageCell.TextContent = record.GetProperty("Age").GetInt32().ToString();
                        row.AppendChild(ageCell);

                        table.AppendChild(row);
                    }

                    // Save the generated HTML to a file
                    document.Save("output.html");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}