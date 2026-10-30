// Define a CSS variable for border color and reference it in the table border-color rule.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create an HTML document from inline content
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define CSS variable for border color and use it in table styles
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = @"
                :root { --border-color: #ff0000; }
                table { border: 2px solid var(--border-color); border-collapse: collapse; }
                th, td { border: 1px solid var(--border-color); padding: 5px; }
            ";
            Aspose.Html.Dom.Element head = document.QuerySelector("head");
            head.AppendChild(styleElement);

            // Create a simple table
            Aspose.Html.Dom.Element table = document.CreateElement("table");

            Aspose.Html.Dom.Element headerRow = document.CreateElement("tr");
            Aspose.Html.Dom.Element th1 = document.CreateElement("th");
            th1.TextContent = "Header 1";
            Aspose.Html.Dom.Element th2 = document.CreateElement("th");
            th2.TextContent = "Header 2";
            headerRow.AppendChild(th1);
            headerRow.AppendChild(th2);
            table.AppendChild(headerRow);

            Aspose.Html.Dom.Element dataRow = document.CreateElement("tr");
            Aspose.Html.Dom.Element td1 = document.CreateElement("td");
            td1.TextContent = "Cell 1";
            Aspose.Html.Dom.Element td2 = document.CreateElement("td");
            td2.TextContent = "Cell 2";
            dataRow.AppendChild(td1);
            dataRow.AppendChild(td2);
            table.AppendChild(dataRow);

            // Append table to body
            Aspose.Html.Dom.Element body = document.QuerySelector("body");
            body.AppendChild(table);

            // Save the document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}