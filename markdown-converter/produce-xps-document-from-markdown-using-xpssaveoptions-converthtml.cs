// Produce an XPS document from Markdown by supplying XpsSaveOptions to the ConvertHTML method.

class Program
{
    static void Main()
    {
        try
        {
            System.String sourcePath = "sample.md";
            System.String savePath = "output.xps";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "# Hello World\nThis is a sample markdown file.");
            }

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            System.Console.WriteLine("Conversion completed. XPS saved to " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}