// Convert an HTML string to a Markdown string by invoking the static Converter.ConvertHTML method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Hello World</h1><p>This is a sample HTML.</p>";
            string baseUri = "http://example.com";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = System.IO.Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);
            Console.WriteLine("Markdown output:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}