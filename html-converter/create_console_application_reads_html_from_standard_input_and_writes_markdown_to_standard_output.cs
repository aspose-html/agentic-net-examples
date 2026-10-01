// Create a console application that reads HTML from standard input and writes Markdown to standard output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            string baseUri = "";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = System.IO.Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);

            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}