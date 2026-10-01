// Convert an EPUB file to DOCX ensuring the output directory exists before writing the file.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "input.epub";
                string outputDir = "output";
                System.IO.Directory.CreateDirectory(outputDir);
                string outputPath = System.IO.Path.Combine(outputDir, "result.docx");

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
}