// Ensure that special characters in HTML are properly escaped in the generated Markdown output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample & Test</title></head><body><h1>Hello \"World\"</h1><p>5 < 10 & 10 > 5</p></body></html>";
            string baseUri = "about:blank";
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
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}