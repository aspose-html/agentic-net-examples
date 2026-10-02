// Apply a GitLab Flavored Markdown template through MarkdownSaveOptions.Template before performing the conversion.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            string outputPath = "output.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);
            System.Console.WriteLine("Conversion completed. Markdown saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}