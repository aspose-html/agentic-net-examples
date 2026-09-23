// Convert an EPUB file to PDF ensuring the output directory exists before writing the file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "result.pdf");

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllBytes(sourcePath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}