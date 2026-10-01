// Load an EPUB file and convert its contents to DOCX using the static Converter class.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "sample.docx";

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("EPUB has been successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}