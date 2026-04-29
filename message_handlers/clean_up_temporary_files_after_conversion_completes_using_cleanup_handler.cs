// Clean up temporary files after conversion completes using a cleanup handler.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
        string baseUri = "http://example.com/";
        MarkdownSaveOptions options = new MarkdownSaveOptions();
        string tempPath = Path.GetTempFileName();
        try
        {
            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
        finally
        {
            if (File.Exists(tempPath))
                File.Delete(tempPath);
        }
    }
}