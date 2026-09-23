// Convert an EPUB file to DOCX and save the output to a user‑specified directory.

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "output.docx";
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);
            System.Console.WriteLine("EPUB successfully converted to DOCX.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}