// Load an HTML file, extract all table elements, and write each table to separate HTML files.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <table border='1'>
        <tr><td>Row1Cell1</td><td>Row1Cell2</td></tr>
        <tr><td>Row2Cell1</td><td>Row2Cell2</td></tr>
    </table>
    <p>Some text between tables.</p>
    <table border='1'>
        <tr><td>A</td><td>B</td></tr>
        <tr><td>C</td><td>D</td></tr>
    </table>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Get all table elements
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

                for (int i = 0; i < tables.Length; i++)
                {
                    // Ensure the node is a table element
                    if (tables[i] is Aspose.Html.HTMLTableElement table)
                    {
                        // Create a new empty HTML document
                        var newDoc = new Aspose.Html.HTMLDocument("<html><head></head><body></body></html>", "about:blank");

                        // Clone the table and append it to the new document's body
                        var clonedTable = (Aspose.Html.HTMLTableElement)table.CloneNode(true);
                        newDoc.Body.AppendChild(clonedTable);

                        // Save each table to a separate file
                        string outputPath = $"table_{i + 1}.html";
                        newDoc.Save(outputPath);
                        newDoc.Dispose();
                    }
                }
            }

            Console.WriteLine("Tables have been extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}