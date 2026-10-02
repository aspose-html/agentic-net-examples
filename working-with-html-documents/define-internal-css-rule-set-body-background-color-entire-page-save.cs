// Define an internal CSS rule to set the body background-color for the entire page and save.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var head = document.QuerySelector("head");
            var style = document.CreateElement("style") as Aspose.Html.Dom.Element;
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";
            head.AppendChild(style);
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("HTML saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}