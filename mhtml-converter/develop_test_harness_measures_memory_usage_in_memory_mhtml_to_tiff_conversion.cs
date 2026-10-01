// Develop a test harness that measures memory usage during in‑memory MHTML to TIFF conversion.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are kept for later use.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><h1>Test MHTML</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Open input stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Create custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Measure memory before conversion
                    long memoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;

                    // Perform in‑memory conversion
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, provider);

                    // Measure memory after conversion
                    long memoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;
                    Console.WriteLine($"Memory used for conversion: {memoryAfter - memoryBefore} bytes");

                    // Save each generated TIFF stream to a file
                    int index = 0;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputFile = $"output_{index}.tiff";
                        using (FileStream fileStream = File.Create(outputFile))
                        {
                            ms.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved TIFF page {index} to {outputFile} (size: {ms.Length} bytes)");
                        index++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}