// Convert an EPUB file to DOCX by reading the source via FileStream with read‑only access.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "output.docx";

            // Create a placeholder EPUB file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            using (FileStream inputStream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
            }

            Console.WriteLine("EPUB has been successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}