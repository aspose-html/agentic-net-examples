// Load an EPUB file and convert its contents to DOCX using the static Converter class.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string epubPath = "input.epub";

            // Desired output DOCX file path
            string docxPath = "output.docx";

            // Open the EPUB file as a read‑only stream
            using (Stream stream = File.OpenRead(epubPath))
            {
                // Create default DOCX saving options
                DocSaveOptions options = new DocSaveOptions();

                // Convert the EPUB stream to DOCX and write to the output path
                Converter.ConvertEPUB(stream, options, docxPath);
            }

            Console.WriteLine("EPUB successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}