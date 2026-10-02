// Create a script that processes a list of ZIP files, extracts HTML, and converts each to PDF.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a sample ZIP file with an HTML document
            string sampleZipPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample1.zip");
            string sampleHtmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            if (!System.IO.File.Exists(sampleZipPath))
            {
                using (var zipToCreate = System.IO.File.Create(sampleZipPath))
                using (var archive = new System.IO.Compression.ZipArchive(zipToCreate, System.IO.Compression.ZipArchiveMode.Create))
                {
                    var entry = archive.CreateEntry("index.html");
                    using (var entryStream = entry.Open())
                    using (var writer = new System.IO.StreamWriter(entryStream))
                    {
                        writer.Write(sampleHtmlContent);
                    }
                }
            }

            // List of ZIP files to process
            string[] zipPaths = new string[] { sampleZipPath };

            foreach (string zipPath in zipPaths)
            {
                // Prepare extraction directory
                string extractDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(),
                    System.IO.Path.GetFileNameWithoutExtension(zipPath));
                System.IO.Directory.CreateDirectory(extractDir);

                // Extract HTML files from the ZIP archive
                using (var zipStream = System.IO.File.OpenRead(zipPath))
                using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
                        {
                            string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                            string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                            if (!string.IsNullOrEmpty(entryFolder))
                            {
                                System.IO.Directory.CreateDirectory(entryFolder);
                            }

                            using (var entryStream = entry.Open())
                            using (var fileStream = System.IO.File.Create(entryPath))
                            {
                                entryStream.CopyTo(fileStream);
                            }
                        }
                    }
                }

                // Locate the extracted HTML file
                string[] htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                {
                    htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.htm", System.IO.SearchOption.AllDirectories);
                }
                if (htmlFiles.Length == 0)
                {
                    throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.", zipPath);
                }

                // Convert HTML to PDF
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                string outputPdfPath = System.IO.Path.ChangeExtension(zipPath, ".pdf");

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine($"Converted '{zipPath}' to PDF at '{outputPdfPath}'.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}