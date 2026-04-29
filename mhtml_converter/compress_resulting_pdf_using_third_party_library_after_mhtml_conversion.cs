// Write a method that compresses the resulting PDF using a third‑party library after MHTML conversion.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input MHTML, intermediate PDF, and final compressed ZIP
            string inputMhtmlPath = Path.Combine(Environment.CurrentDirectory, "input.mhtml");
            string outputPdfPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");
            string outputZipPath = Path.Combine(Environment.CurrentDirectory, "output.zip");

            // Ensure the input file exists
            if (!File.Exists(inputMhtmlPath))
                throw new FileNotFoundException("MHTML input file not found.", inputMhtmlPath);

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputMhtmlPath))
            {
                // Create default PDF save options
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert MHTML to PDF and save to the specified path
                Converter.ConvertMHTML(stream, pdfOptions, outputPdfPath);
            }

            // Compress the generated PDF into a ZIP archive using built‑in compression
            using (FileStream zipToOpen = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                // Add the PDF file to the archive with optimal compression
                archive.CreateEntryFromFile(outputPdfPath, Path.GetFileName(outputPdfPath), CompressionLevel.Optimal);
            }

            Console.WriteLine("Conversion and compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}