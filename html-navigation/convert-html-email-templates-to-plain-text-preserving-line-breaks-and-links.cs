// Convert HTML email templates to plain text while preserving line breaks and links.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<html>
  <body>
    <h1>Welcome to Our Newsletter</h1>
    <p>Hello John,</p>
    <p>We are excited to share the latest updates with you.</p>
    <p>Visit our <a href=""https://www.example.com"">website</a> for more details.</p>
    <p>Best regards,<br/>The Team</p>
  </body>
</html>";
            string baseUri = "about:blank";
            string outputPath = "email_plain_text.txt";

            TextSaveOptions options = new TextSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"Plain text email saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}