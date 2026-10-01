// Convert an HTML file to a DOCX document using default DocSaveOptions via the one‑line Converter method.

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "result.docx";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><h1>Hello, World!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}