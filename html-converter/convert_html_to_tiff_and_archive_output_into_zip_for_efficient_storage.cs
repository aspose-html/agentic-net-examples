// Convert HTML to TIFF and archive the output file into a ZIP archive for efficient storage.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare working directory
            string workDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AsposeHtmlExample");
            System.IO.Directory.CreateDirectory(workDir);

            // Create sample HTML file
            string htmlPath = System.IO.Path.Combine(workDir, "sample.html");
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Define output TIFF path
            string tiffPath = System.IO.Path.Combine(workDir, "output.tiff");

            // Load HTML document
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Set image save options for TIFF
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                options.BackgroundColor = System.Drawing.Color.White;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert HTML to TIFF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, tiffPath);
            }

            // Create ZIP archive containing the TIFF
            string zipPath = System.IO.Path.Combine(workDir, "output.zip");
            using (System.IO.FileStream zipStream = new System.IO.FileStream(zipPath, System.IO.FileMode.Create))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
            {
                System.IO.Compression.ZipArchiveEntry entry = archive.CreateEntry(System.IO.Path.GetFileName(tiffPath));
                using (System.IO.Stream entryStream = entry.Open())
                using (System.IO.FileStream tiffFileStream = new System.IO.FileStream(tiffPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    tiffFileStream.CopyTo(entryStream);
                }
            }

            System.Console.WriteLine("HTML has been converted to TIFF and archived successfully.");
            System.Console.WriteLine("TIFF path: " + tiffPath);
            System.Console.WriteLine("ZIP path: " + zipPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}