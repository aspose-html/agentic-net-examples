// Convert an EPUB file to DOCX while preserving original document styles and headings.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.epub";
                string outputPath = "output.docx";

                using (System.IO.FileStream stream = System.IO.File.OpenRead(sourcePath))
                {
                    Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                System.Console.WriteLine("EPUB successfully converted to DOCX.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}