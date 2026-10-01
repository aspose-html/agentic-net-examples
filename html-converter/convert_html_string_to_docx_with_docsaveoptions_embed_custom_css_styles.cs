// Convert an HTML string to a DOCX file while applying DocSaveOptions to embed custom CSS styles.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><style>body{font-family:Arial;}</style></head><body><h1>Hello, World!</h1><p>This is a sample document.</p></body></html>";
            string outputPath = "sample.docx";
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(html, "", options, outputPath);
            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}