// Generate a PDF preview by converting Markdown to HTML and then to an XPS document.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a **test** markdown file.");
            }

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            System.Console.WriteLine("Conversion completed successfully. XPS saved to: " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}