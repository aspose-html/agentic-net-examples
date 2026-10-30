// Convert Markdown to HTML, apply CSS styling, and then save the output as a PNG image.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string markdownContent = "# Hello World\r\nThis is a **markdown** sample.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                Aspose.Html.HTMLStyleElement style = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                style.TextContent = "body { font-family: Arial; background-color: #f0f0f0; } h1 { color: #ff0000; }";
                head.AppendChild(style);

                string outputPath = "output.png";
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                System.Console.WriteLine("Conversion completed. PNG saved at " + System.IO.Path.GetFullPath(outputPath));
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}