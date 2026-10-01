// Convert the HTML document to plain text while preserving line breaks for readability.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello</h1><p>World</p></body></html>";
            string baseUri = "";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string plainText = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Plain text output:");
            Console.WriteLine(plainText);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}