// Define a CSS variable for border color and reference it in the table border-color rule.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<!DOCTYPE html><html><head></head><body></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

                Aspose.Html.Dom.Element style = document.CreateElement("style");
                style.TextContent = ":root { --border-color: #ff0000; } table { border: 2px solid var(--border-color); border-collapse: collapse; } td, th { border: 1px solid var(--border-color); padding: 5px; }";

                Aspose.Html.Dom.Element head = document.QuerySelector("head");
                head.AppendChild(style);

                Aspose.Html.Dom.Element table = document.CreateElement("table");
                Aspose.Html.Dom.Element tr = document.CreateElement("tr");
                Aspose.Html.Dom.Element th = document.CreateElement("th");
                th.TextContent = "Header";
                tr.AppendChild(th);
                Aspose.Html.Dom.Element td = document.CreateElement("td");
                td.TextContent = "Cell";
                tr.AppendChild(td);
                table.AppendChild(tr);

                Aspose.Html.Dom.Element body = document.QuerySelector("body");
                body.AppendChild(table);

                document.Save("output.html");
                Console.WriteLine("HTML document saved to output.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}