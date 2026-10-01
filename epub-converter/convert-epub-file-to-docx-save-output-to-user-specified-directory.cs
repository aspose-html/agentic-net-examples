// Convert an EPUB file to DOCX and save the output to a user‑specified directory.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputDirectory = "output";
            System.IO.Directory.CreateDirectory(outputDirectory);
            string outputPath = System.IO.Path.Combine(outputDirectory, "sample.docx");

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("EPUB successfully converted to DOCX: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}