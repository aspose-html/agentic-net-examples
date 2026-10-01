// Save the updated Markdown document preserving the original file encoding and line ending style.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = Aspose.Html.Saving.MarkdownSaveOptions.Git;
            string htmlContent = "<h1>Sample Title</h1><p>This is a paragraph.</p>";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);
            Console.WriteLine("Markdown saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}