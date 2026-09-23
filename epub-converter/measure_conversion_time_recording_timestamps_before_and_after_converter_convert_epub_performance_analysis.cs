// Measure conversion time by recording timestamps before and after calling Converter.ConvertEPUB for performance analysis.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

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
        // No action needed for in-memory streams
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

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                XpsSaveOptions options = new XpsSaveOptions();
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);
                    sw.Stop();

                    Console.WriteLine($"Conversion time: {sw.Elapsed}");

                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream firstStream = provider.Streams[0];
                        firstStream.Position = 0;
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            firstStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Output saved to {outputPath}");
                    }
                    else
                    {
                        Console.WriteLine("No output streams were generated.");
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