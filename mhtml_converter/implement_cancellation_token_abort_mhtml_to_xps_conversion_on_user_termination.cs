// Implement a cancellation token that aborts MHTML to XPS conversion when the user requests termination.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input.mhtml> <output.xps>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        var cts = new CancellationTokenSource();

        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
            Console.WriteLine("Cancellation requested...");
        };

        try
        {
            ConvertMhtmlToXps(inputPath, outputPath, cts.Token);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Conversion was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToXps(string inputPath, string outputPath, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        using (FileStream inputStream = File.OpenRead(inputPath))
        using (var provider = new MemoryStreamProvider())
        {
            XpsSaveOptions options = new XpsSaveOptions();

            token.ThrowIfCancellationRequested();

            Converter.ConvertMHTML(inputStream, options, provider);

            token.ThrowIfCancellationRequested();

            // Retrieve the first generated XPS stream from the provider
            MemoryStream xpsStream = provider.GetFirstStream();
            if (xpsStream == null)
                throw new InvalidOperationException("No XPS data was generated.");

            xpsStream.Position = 0;
            using (FileStream outputFile = File.Create(outputPath))
            {
                xpsStream.CopyTo(outputFile);
            }
        }
    }

    // Simple ICreateStreamProvider implementation that stores streams in memory
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        private readonly List<MemoryStream> _streams = new List<MemoryStream>();
        private bool _disposed = false;

        public Stream GetStream(string path, string contentType)
        {
            var ms = new MemoryStream();
            _streams.Add(ms);
            return ms;
        }

        public Stream GetStream(string path, string contentType, int bufferSize)
        {
            var ms = new MemoryStream();
            _streams.Add(ms);
            return ms;
        }

        public void ReleaseStream(Stream stream)
        {
            // No action needed for in-memory streams
        }

        public MemoryStream GetFirstStream()
        {
            return _streams.Count > 0 ? _streams[0] : null;
        }

        public void Dispose()
        {
            if (_disposed) return;
            foreach (var ms in _streams)
                ms.Dispose();
            _streams.Clear();
            _disposed = true;
        }
    }
}