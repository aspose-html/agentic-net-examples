// Convert EPUB to GIF and obtain the output stream via ICreateStreamProvider for in‑memory usage.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Converters;

namespace EpubToGifExample
{
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();
        public Stream GetStream(string name, string extension)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }
        public Stream GetStream(string name, string extension, int page)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }
        public void ReleaseStream(Stream stream) { }
        public void Dispose()
        {
            foreach (var ms in Streams) ms.Dispose();
        }
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
                using var fileStream = File.OpenRead("sample.epub");
                var epubMemory = new MemoryStream();
                fileStream.CopyTo(epubMemory);
                epubMemory.Position = 0;

                var options = new ImageSaveOptions(ImageFormat.Gif);
                using var provider = new MemoryStreamProvider();

                Converter.ConvertEPUB(epubMemory, options, provider);

                var gifStream = provider.GetFirstStream();
                if (gifStream != null)
                {
                    gifStream.Position = 0;
                    using var outputFile = File.Create("output.gif");
                    gifStream.CopyTo(outputFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}