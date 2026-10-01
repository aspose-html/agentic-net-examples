// Ensure the Markdown file ends with a single newline character to satisfy parser requirements.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample HTML converted to Markdown.</p></body></html>";
            string baseUri = "";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);

            File.Delete(tempPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
