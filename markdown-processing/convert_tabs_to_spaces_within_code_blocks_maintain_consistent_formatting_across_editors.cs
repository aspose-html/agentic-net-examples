// Convert tabs to spaces within code blocks to maintain consistent formatting across editors.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html>\n<body>\n\t<p>Hello\tWorld</p>\n</body>\n</html>";
            string outputPath = "output.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);
            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}