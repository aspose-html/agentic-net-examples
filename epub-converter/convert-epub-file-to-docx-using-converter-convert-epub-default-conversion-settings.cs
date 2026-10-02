// Convert an EPUB file to DOCX using Converter.ConvertEPUB with default conversion settings.

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "input.epub";
            string outputPath = "output.docx";
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);
            System.Console.WriteLine("EPUB converted to DOCX successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}