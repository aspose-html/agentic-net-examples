// Convert EPUB to PNG and pipe the output into a FileStream for efficient disk writing.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

namespace EpubToPng
{
    // Custom stream provider that stores each generated image in a MemoryStream
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        // Called by Aspose.HTML to obtain a stream for a page image
        public Stream GetStream(string name, string extension)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        // Overload with page index (used for multi‑page output)
        public Stream GetStream(string name, string extension, int page)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public void ReleaseStream(Stream stream)
        {
            stream?.Flush();
        }

        public void Dispose()
        {
            foreach (var ms in Streams)
                ms.Dispose();
        }

        // Helper to retrieve the first generated image stream
        public MemoryStream GetFirstStream()
        {
            return Streams.Count > 0 ? Streams[0] : null;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source EPUB file
                string epubPath = "input.epub";
                // Path where the first PNG page will be saved
                string outputPath = "output.png";

                // Open the EPUB file as a read‑only stream
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Set default image save options (PNG is the default format)
                    ImageSaveOptions options = new ImageSaveOptions();

                    // Create the custom provider to capture image streams in memory
                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        // Perform the conversion: EPUB -> PNG images (one per page)
                        Converter.ConvertEPUB(epubStream, options, provider);

                        // Retrieve the first generated image stream
                        MemoryStream firstImage = provider.GetFirstStream();
                        if (firstImage != null)
                        {
                            firstImage.Position = 0; // Ensure the stream is at the beginning

                            // Write the image data directly to a file stream for efficient disk I/O
                            using (FileStream fileStream = File.Create(outputPath))
                            {
                                firstImage.CopyTo(fileStream);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No image streams were generated.");
                        }
                    }
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}