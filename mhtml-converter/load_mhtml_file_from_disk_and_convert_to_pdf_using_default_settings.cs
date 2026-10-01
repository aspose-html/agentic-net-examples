// Load an MHTML file from disk and convert it to PDF using default settings.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}