// Ensure that temporary HTML files created during conversion are deleted after the final output is saved.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample HTML.</p></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            string outputPath = "output.md";
            File.WriteAllText(outputPath, markdown);

            Console.WriteLine($"Markdown saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}