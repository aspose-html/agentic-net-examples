// Use Document.QuerySelectorAll to locate all elements with style attribute containing "color:red" and change to blue.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p style='color:red'>Red text</p><div style='font-size:12px; color:red'>Another red</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[style*='color:red']");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.Color = "blue";
            }
            document.Save("output.html");
            System.Console.WriteLine("Processing completed. Output saved to output.html");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}