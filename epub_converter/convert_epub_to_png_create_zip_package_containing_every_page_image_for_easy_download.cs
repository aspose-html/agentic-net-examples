// Convert EPUB to PNG and create a ZIP package containing every page image for easy download.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;
using System.IO.Compression;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string epubPath = "sample.epub";
                string zipPath = "output_images.zip";

                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();

                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        Converter.ConvertEPUB(epubStream, options, provider);

                        using (FileStream zipFile = new FileStream(zipPath, FileMode.Create))
                        using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                        {
                            int index = 0;
                            foreach (MemoryStream ms in provider.Streams)
                            {
                                ms.Position = 0;
                                string entryName = $"page{index}.png";
                                ZipArchiveEntry entry = archive.CreateEntry(entryName);
                                using (Stream entryStream = entry.Open())
                                {
                                    ms.CopyTo(entryStream);
                                }
                                index++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        public Stream GetStream(string path, string mimeType)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public Stream GetStream(string path, string mimeType, int pageNumber)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public void ReleaseStream(Stream stream)
        {
        }

        public void Dispose()
        {
            foreach (var ms in Streams)
            {
                ms.Dispose();
            }
        }
    }
}