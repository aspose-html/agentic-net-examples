// Convert the HTML document to plain text while preserving line breaks for readability.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Title</h1><p>First line.<br/>Second line.</p></body></html>";
            string baseUri = "about:blank";

            MarkdownSaveOptions options = new MarkdownSaveOptions();

            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string plainText = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Converted plain text:");
            Console.WriteLine(plainText);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}