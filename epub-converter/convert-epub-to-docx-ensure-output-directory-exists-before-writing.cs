// Convert an EPUB file to DOCX ensuring the output directory exists before writing the file.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "input.epub";
            string outputPath = "output/result.docx";

            string outputDir = System.IO.Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                System.IO.Directory.CreateDirectory(outputDir);
            }

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("EPUB successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}