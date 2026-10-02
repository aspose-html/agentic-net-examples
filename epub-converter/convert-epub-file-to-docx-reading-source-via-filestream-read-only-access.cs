// Convert an EPUB file to DOCX by reading the source via FileStream with read‑only access.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.epub";
            string outputPath = "output.docx";

            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}