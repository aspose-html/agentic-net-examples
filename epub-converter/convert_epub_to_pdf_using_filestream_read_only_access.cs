// Convert an EPUB file to PDF by reading the source via FileStream with read‑only access.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "sample.epub");
                string outputPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "sample.pdf");

                if (!System.IO.File.Exists(inputPath))
                {
                    using (var zip = new System.IO.Compression.ZipArchive(System.IO.File.Create(inputPath), System.IO.Compression.ZipArchiveMode.Create))
                    {
                        var entry = zip.CreateEntry("mimetype");
                        using (var entryStream = entry.Open())
                        using (var writer = new System.IO.StreamWriter(entryStream))
                        {
                            writer.Write("application/epub+zip");
                        }
                    }
                }

                using (System.IO.Stream epubStream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                }

                System.Console.WriteLine("EPUB converted to PDF successfully. Output: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}