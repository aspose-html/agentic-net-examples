// Parallelize conversion of multiple EPUB files to JPEG using Parallel.ForEach to improve processing throughput.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No action needed; streams are retained for later use.
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
            string inputDir = "InputEpubs";
            string outputDir = "OutputJpegs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Example EPUB files; ensure these files exist in the InputEpubs folder.
            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");

            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    using (FileStream epubStream = File.OpenRead(epubPath))
                    {
                        var options = new ImageSaveOptions(ImageFormat.Jpeg);
                        using (var provider = new MemoryStreamProvider())
                        {
                            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                            string baseName = Path.GetFileNameWithoutExtension(epubPath);
                            for (int i = 0; i < provider.Streams.Count; i++)
                            {
                                MemoryStream ms = provider.Streams[i];
                                ms.Position = 0;
                                string outputPath = Path.Combine(outputDir, $"{baseName}_page{i + 1}.jpg");
                                using (FileStream outFile = File.Create(outputPath))
                                {
                                    ms.CopyTo(outFile);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}