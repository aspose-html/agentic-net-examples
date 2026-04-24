// Convert EPUB to BMP and store the resulting image bytes in a memory stream via provider.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Converters;

namespace EpubToBmp
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
                using (Stream epubStream = File.OpenRead("input.epub"))
                {
                    var options = new ImageSaveOptions(ImageFormat.Bmp);
                    using (var provider = new MemoryStreamProvider())
                    {
                        Converter.ConvertEPUB(epubStream, options, provider);
                        var imageBytes = provider.GetFirstStream()?.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}