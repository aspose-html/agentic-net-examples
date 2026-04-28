// Convert HTML email templates to plain text while preserving line breaks and links.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello, <a href=\"https://example.com\">click here</a> to visit.</p></body></html>";
            string baseUri = "file:///";
            string outputPath = "email.txt";
            TextSaveOptions options = new TextSaveOptions();
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}