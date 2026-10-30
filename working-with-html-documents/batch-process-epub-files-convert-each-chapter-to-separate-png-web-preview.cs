// Batch process EPUB files, converting each chapter to a separate PNG for web preview.

using System;
using System.IO;
using System.Collections.Generic;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            foreach (string epubPath in Directory.GetFiles(dataDir, "*.epub"))
            {
                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;

                    using (var provider = new MemoryStreamProvider())
                    {
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                        int index = 1;
                        foreach (MemoryStream ms in provider.Streams)
                        {
                            ms.Position = 0;
                            string outputPath = Path.Combine(
                                outputDir,
                                $"{Path.GetFileNameWithoutExtension(epubPath)}_chapter_{index}.png");

                            using (FileStream outFile = File.Create(outputPath))
                            {
                                ms.CopyTo(outFile);
                            }
                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}