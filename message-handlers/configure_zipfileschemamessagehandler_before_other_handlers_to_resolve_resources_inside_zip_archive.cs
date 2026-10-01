// Configure ZipFileSchemaMessageHandler before other handlers to resolve resources inside a ZIP archive.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string extractDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "HtmlFromZip");
            System.IO.Directory.CreateDirectory(extractDir);

            using (System.IO.FileStream zipStream = System.IO.File.OpenRead(zipPath))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                        string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            System.IO.Directory.CreateDirectory(entryFolder);

                        using (var entryStream = entry.Open())
                        using (var fileStream = System.IO.File.Create(entryPath))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            string[] htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.htm", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Additional network handlers can be added here if needed.

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice("output.pdf"))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}