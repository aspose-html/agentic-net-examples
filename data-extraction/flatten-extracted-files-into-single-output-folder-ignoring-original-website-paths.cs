// Flatten all extracted files into a single output folder, ignoring original website paths.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Input folder containing ZIP archives
            string inputFolder = "InputZips";
            // Output folder where all extracted HTML files will be flattened
            string outputFolder = "FlattenedOutput";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Process each ZIP file in the input folder
            foreach (string zipPath in Directory.GetFiles(inputFolder, "*.zip"))
            {
                using (FileStream zipStream = File.OpenRead(zipPath))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        // Consider only HTML files
                        if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                        {
                            // Flatten: ignore original directory structure, use only file name
                            string destPath = Path.Combine(outputFolder, Path.GetFileName(entry.FullName));
                            // Ensure unique file name in case of duplicates
                            int duplicateIndex = 1;
                            while (File.Exists(destPath))
                            {
                                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(entry.FullName);
                                string extension = Path.GetExtension(entry.FullName);
                                string newFileName = $"{fileNameWithoutExt}_{duplicateIndex}{extension}";
                                destPath = Path.Combine(outputFolder, newFileName);
                                duplicateIndex++;
                            }
                            entry.ExtractToFile(destPath, true);
                        }
                    }
                }
            }

            // Convert each extracted HTML file to PDF (optional demonstration of Aspose.HTML)
            foreach (string htmlPath in Directory.GetFiles(outputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    using (PdfDevice device = new PdfDevice(pdfPath))
                    {
                        document.RenderTo(device);
                    }
                }
            }

            Console.WriteLine("Extraction and conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}