// Ensure that temporary HTML files created during conversion are deleted after the final output is saved.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = "about:blank";
            var options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = System.IO.Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);

            string outputPath = "output.md";
            System.IO.File.WriteAllText(outputPath, markdown);

            Console.WriteLine($"Markdown saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}