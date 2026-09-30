// Convert a Markdown string to HTML, inject custom CSS into the head, and save the styled page.

public class Program
{
    public static void Main()
    {
        try
        {
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            string baseUri = "";
            string css = "body { font-family: Arial; background-color: #f0f0f0; } h1 { color: #336699; }";
            string outputPath = "styled.html";

            System.IO.MemoryStream stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown));
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, baseUri);

            Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
            styleElement.TextContent = css;
            head.AppendChild(styleElement);

            document.Save(outputPath);
            System.Console.WriteLine(document.DocumentElement.OuterHTML);
            System.Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}