// Convert an EPUB file to DOCX by writing the output using FileStream with create‑new mode.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.docx";

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                DocSaveOptions options = new DocSaveOptions();

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Converter.ConvertEPUB(epubStream, options, provider);

                    MemoryStream resultStream = provider.GetFirstStream();
                    resultStream.Position = 0;

                    using (FileStream fileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        resultStream.WriteTo(fileStream);
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

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string path, string mimeType)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string mimeType, int bufferSize)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No special handling required; streams are managed internally.
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
        if (_streams.Count == 0)
            throw new InvalidOperationException("No streams were created.");
        return _streams[0];
    }
}