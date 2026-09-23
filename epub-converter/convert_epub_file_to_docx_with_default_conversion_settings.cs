// Convert an EPUB file to DOCX using Converter.ConvertEPUB with default conversion settings.

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

            if (!File.Exists(sourcePath))
            {
                // Create a minimal empty EPUB file as placeholder
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            var options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("EPUB has been successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}