// Write the MemoryStream obtained from BMP conversion to a FileStream and verify file integrity.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int index)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No special handling required for MemoryStream
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    public MemoryStream GetFirstStream()
    {
        return _streams.Count > 0 ? _streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string epubPath = "sample.epub";

            // Output BMP file path
            string outputPath = "output.bmp";

            // Open EPUB as a stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Set image save options to BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Create custom memory stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to BMP, result stored in provider's memory streams
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the first generated image stream
                    MemoryStream imageStream = provider.GetFirstStream();
                    if (imageStream == null)
                        throw new InvalidOperationException("No image stream was generated.");

                    // Write memory stream to a file
                    imageStream.Position = 0;
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        imageStream.CopyTo(fileStream);
                    }

                    // Verify file integrity by comparing bytes
                    byte[] originalBytes = imageStream.ToArray();
                    byte[] fileBytes = File.ReadAllBytes(outputPath);
                    bool isIdentical = originalBytes.Length == fileBytes.Length;
                    if (isIdentical)
                    {
                        for (int i = 0; i < originalBytes.Length; i++)
                        {
                            if (originalBytes[i] != fileBytes[i])
                            {
                                isIdentical = false;
                                break;
                            }
                        }
                    }

                    Console.WriteLine(isIdentical
                        ? "File written successfully and integrity verified."
                        : "File integrity check failed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}