// Convert an EPUB file to DOCX by writing the output using FileStream with create‑new mode.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
        if (stream != null)
        {
            stream.Flush();
        }
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
            string sourcePath = "sample.epub";
            string outputPath = "output.docx";

            // Ensure the source file exists (create a minimal placeholder if needed)
            if (!File.Exists(sourcePath))
            {
                File.WriteAllBytes(sourcePath, new byte[] { });
            }

            using (Stream inputStream = File.OpenRead(sourcePath))
            {
                var provider = new MemoryStreamProvider();
                var options = new Aspose.Html.Saving.DocSaveOptions();

                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                if (provider.Streams.Count == 0)
                {
                    throw new InvalidOperationException("No output stream was generated.");
                }

                using (var resultStream = provider.Streams[0])
                {
                    resultStream.Position = 0;
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }

                provider.Dispose();
            }

            Console.WriteLine("EPUB successfully converted to DOCX: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}