// Use QuerySelector to find the first table element and add a caption describing its purpose.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><table><tr><td>Cell</td></tr></table></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element tableElement = document.QuerySelector("table");
            if (tableElement != null)
            {
                Aspose.Html.HTMLElement caption = (Aspose.Html.HTMLElement)document.CreateElement("caption");
                caption.TextContent = "This table displays sample data.";
                tableElement.AppendChild(caption);
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("HTML document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}