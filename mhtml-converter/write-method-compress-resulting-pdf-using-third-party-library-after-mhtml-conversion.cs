// Write a method that compresses the resulting PDF using a third‑party library after MHTML conversion.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputMhtmlPath = "sample.mhtml";
            string outputPdfPath = "result.pdf";
            string outputZipPath = "result.zip";

            // Create a minimal MHTML file (for demonstration purposes)
            string minimalMhtmlContent = "<html><body><p>Hello, Aspose.HTML!</p></body></html>";
            System.IO.File.WriteAllText(inputMhtmlPath, minimalMhtmlContent);

            // Convert MHTML to PDF
            using (System.IO.Stream mhtmlStream = System.IO.File.OpenRead(inputMhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, pdfOptions, outputPdfPath);
            }

            Console.WriteLine($"PDF generated at: {outputPdfPath}");

            // Compress the resulting PDF using standard .NET compression (ZIP)
            using (System.IO.FileStream zipToOpen = new System.IO.FileStream(outputZipPath, System.IO.FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                ZipArchiveEntry pdfEntry = archive.CreateEntry(System.IO.Path.GetFileName(outputPdfPath));
                using (System.IO.Stream entryStream = pdfEntry.Open())
                using (System.IO.FileStream pdfFileStream = new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    pdfFileStream.CopyTo(entryStream);
                }
            }

            Console.WriteLine($"Compressed PDF saved as ZIP at: {outputZipPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}