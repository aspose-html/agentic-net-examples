// Export every page of an EPUB as individual BMP images using ImageSaveOptions to control per‑page rendering.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

namespace EpubToBmpPages
{
    // Custom stream provider that captures each page output in a MemoryStream
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        // Called by the converter to obtain a stream for a page (no page number)
        public Stream GetStream(string suggestedFileName, string mimeType)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        // Called by the converter to obtain a stream for a specific page number
        public Stream GetStream(string suggestedFileName, string mimeType, int pageNumber)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        // Called after the converter finishes writing to a stream
        public void ReleaseStream(Stream stream)
        {
            // No additional action required
        }

        // Dispose all captured streams
        public void Dispose()
        {
            foreach (var ms in Streams)
            {
                ms.Dispose();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input EPUB file path
                string epubPath = "sample.epub";

                // Directory where individual BMP images will be saved
                string outputDir = "output";
                Directory.CreateDirectory(outputDir);

                // Open the EPUB file as a stream
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Configure image save options for BMP format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                    // Create the custom stream provider
                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        // Convert EPUB; each page will be written to a separate MemoryStream
                        Converter.ConvertEPUB(epubStream, options, provider);

                        // Save each captured stream as an individual BMP file
                        for (int i = 0; i < provider.Streams.Count; i++)
                        {
                            MemoryStream ms = provider.Streams[i];
                            ms.Position = 0; // Reset position before reading

                            string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
                            using (FileStream file = File.Create(outputPath))
                            {
                                ms.CopyTo(file);
                            }
                        }
                    }
                }

                Console.WriteLine("EPUB pages have been exported as BMP images successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}