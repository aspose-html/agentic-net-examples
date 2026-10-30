// Convert an EPUB file to DOCX using Converter.ConvertEPUB with default conversion settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "result.docx";

            // Create a placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllBytes(sourcePath, new byte[0]);
            }

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);
            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}