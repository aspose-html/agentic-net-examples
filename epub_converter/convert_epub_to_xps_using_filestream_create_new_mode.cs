// Convert an EPUB file to XPS by writing the output using FileStream with create‑new mode.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.IO;

namespace EpubToXps
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

        public void ReleaseStream(Stream stream)
        {
            // No special handling needed
        }

        public MemoryStream GetFirstStream()
        {
            return Streams.Count > 0 ? Streams[0] : null;
        }

        public void Dispose()
        {
            foreach (var ms in Streams)
            {
                ms.Dispose();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string inputPath = "input.epub";
            const string outputPath = "output.xps";

            try
            {
                using (Stream epubStream = File.OpenRead(inputPath))
                {
                    XpsSaveOptions options = new XpsSaveOptions();

                    using (var provider = new MemoryStreamProvider())
                    {
                        Converter.ConvertEPUB(epubStream, options, provider);

                        MemoryStream resultStream = provider.GetFirstStream();
                        if (resultStream == null)
                            throw new InvalidOperationException("No output stream was generated.");

                        resultStream.Position = 0;

                        using (FileStream fileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                        {
                            resultStream.WriteTo(fileStream);
                        }
                    }
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}