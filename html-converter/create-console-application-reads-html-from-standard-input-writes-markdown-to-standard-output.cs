// Create a console application that reads HTML from standard input and writes Markdown to standard output.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}