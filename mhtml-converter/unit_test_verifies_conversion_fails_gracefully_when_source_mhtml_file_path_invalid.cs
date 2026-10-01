// Create a unit test that verifies conversion fails gracefully when the source MHTML file path is invalid.

class Program
{
    static void Main()
    {
        try
        {
            RunInvalidMhtmlConversionTest();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    static void RunInvalidMhtmlConversionTest()
    {
        string sourcePath = "nonexistent.mhtml";
        string outputPath = "output.pdf";

        try
        {
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
            System.Console.WriteLine("Test Failed: No exception thrown for invalid source path.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Test Passed: Caught expected exception - " + ex.GetType().Name);
        }
    }
}