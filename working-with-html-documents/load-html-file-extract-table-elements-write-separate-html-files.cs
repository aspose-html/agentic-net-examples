// Load an HTML file, extract all table elements, and write each table to separate HTML files.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><table><tr><td>Cell 1</td></tr></table><table><tr><td>Cell 2</td></tr></table></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

                for (int i = 0; i < tables.Length; i++)
                {
                    var tableNode = tables[i] as Aspose.Html.HTMLTableElement;
                    if (tableNode != null)
                    {
                        Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument("<html><body></body></html>", "about:blank");
                        Aspose.Html.Dom.Element clonedTable = (Aspose.Html.Dom.Element)tableNode.CloneNode(true);
                        newDoc.Body.AppendChild(clonedTable);

                        string outputPath = $"table{i + 1}.html";
                        newDoc.Save(outputPath);
                        newDoc.Dispose();
                    }
                }
            }

            Console.WriteLine("Tables extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}