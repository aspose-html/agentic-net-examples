// Convert HTML email templates to plain text while preserving line breaks and links.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample email.<br/>Visit <a href=\"https://example.com\">our site</a> for more info.</p></body></html>";
            string baseUri = "";
            string outputPath = "email.txt";

            Aspose.Html.Saving.TextSaveOptions options = new Aspose.Html.Saving.TextSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}