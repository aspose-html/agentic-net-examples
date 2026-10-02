// Export an EPUB chapter to PDF, preserving embedded images and text formatting.

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "chapter.pdf");

            using (System.IO.FileStream stream = new System.IO.FileStream(inputPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("EPUB chapter converted to PDF successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}