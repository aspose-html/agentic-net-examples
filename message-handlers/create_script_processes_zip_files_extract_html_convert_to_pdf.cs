// Create a script that processes a list of ZIP files, extracts HTML, and converts each to PDF.

using System;
using System.IO;
using System.IO.Compression;

namespace ZipHtmlToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] zipPaths = new string[] { "sample1.zip", "sample2.zip" };
                foreach (string zipPath in zipPaths)
                {
                    string extractDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileNameWithoutExtension(zipPath));
                    System.IO.Directory.CreateDirectory(extractDirectory);
                    using (System.IO.FileStream zipStream = System.IO.File.OpenRead(zipPath))
                    using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
                    {
                        foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                                entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
                            {
                                string entryPath = System.IO.Path.Combine(extractDirectory, entry.FullName);
                                string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                                if (!string.IsNullOrEmpty(entryFolder))
                                    System.IO.Directory.CreateDirectory(entryFolder);
                                entry.ExtractToFile(entryPath, true);
                            }
                        }
                    }

                    string[] htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.html", System.IO.SearchOption.AllDirectories);
                    if (htmlFiles.Length == 0)
                        htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.htm", System.IO.SearchOption.AllDirectories);
                    if (htmlFiles.Length == 0)
                        throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.", zipPath);

                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    string outputPdfPath = System.IO.Path.ChangeExtension(zipPath, ".pdf");
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
                    using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
                    {
                        document.RenderTo(device);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}