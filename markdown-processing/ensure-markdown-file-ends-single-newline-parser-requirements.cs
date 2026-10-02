// Ensure the Markdown file ends with a single newline character to satisfy parser requirements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1><p>This is a sample HTML.</p></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = System.IO.Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}
