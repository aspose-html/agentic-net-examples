// Convert HTML email templates to plain text while preserving line breaks and links.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><p>Hello,</p><p>Please visit <a href=\"https://example.com\">our site</a> for more info.</p><p>Thanks!</p></body></html>";
            string baseUri = "about:blank";
            string outputPath = "email.txt";

            Aspose.Html.Saving.TextSaveOptions options = new Aspose.Html.Saving.TextSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}