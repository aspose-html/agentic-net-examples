// Parallelize conversion of multiple EPUB files to JPEG using Parallel.ForEach to improve processing throughput.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Converters;

namespace EpupToJpegParallel
{
    // Custom provider that creates a MemoryStream for each page and stores them.
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        // Called by Aspose when a new output stream is required (without page number).
        public Stream GetStream(string path, string extension)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        // Called by Aspose when a new output stream is required for a specific page.
        public Stream GetStream(string path, string extension, int pageNumber)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        // Called after writing is finished; no special handling needed.
        public void ReleaseStream(Stream stream) { /* no action needed */ }

        // Dispose all created memory streams.
        public void Dispose()
        {
            foreach (var ms in Streams)
            {
                ms.Dispose();
            }
            Streams.Clear();
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Directory containing EPUB files.
                string inputDir = @"C:\Epubs";
                // Directory where JPEG images will be saved.
                string outputDir = @"C:\JpegOutput";

                Directory.CreateDirectory(outputDir);

                // Get all EPUB file paths.
                var epubFiles = Directory.GetFiles(inputDir, "*.epub", SearchOption.TopDirectoryOnly);

                // Process each EPUB file in parallel.
                Parallel.ForEach(epubFiles, epubPath =>
                {
                    // Base name without extension for output files.
                    string baseName = Path.GetFileNameWithoutExtension(epubPath);

                    using (FileStream epubStream = File.OpenRead(epubPath))
                    using (var provider = new MemoryStreamProvider())
                    {
                        // Configure JPEG output format.
                        var options = new ImageSaveOptions(ImageFormat.Jpeg);

                        // Convert EPUB to JPEG images, each page goes to a MemoryStream.
                        Converter.ConvertEPUB(epubStream, options, provider);

                        // Save each generated page image to a separate JPEG file.
                        for (int i = 0; i < provider.Streams.Count; i++)
                        {
                            var pageStream = provider.Streams[i];
                            pageStream.Position = 0; // Reset position before reading.

                            string outputPath = Path.Combine(outputDir,
                                $"{baseName}_page{i + 1}.jpg");

                            using (FileStream fileStream = File.Create(outputPath))
                            {
                                pageStream.CopyTo(fileStream);
                            }
                        }
                    }
                });

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}