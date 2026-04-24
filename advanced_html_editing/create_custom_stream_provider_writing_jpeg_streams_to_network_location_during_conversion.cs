// Create a custom ICreateStreamProvider that writes JPEG streams to a network location during conversion.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace AsposeHtmlNetworkStreamExample
{
    // Custom stream provider that writes JPEG streams directly to a network location.
    public class NetworkStreamProvider : ICreateStreamProvider, IDisposable
    {
        private readonly string _networkFolder;
        private readonly List<Stream> _openedStreams = new List<Stream>();

        public NetworkStreamProvider(string networkFolder)
        {
            _networkFolder = networkFolder;
        }

        // Creates a stream for a given name and extension.
        public Stream GetStream(string name, string extension)
        {
            return CreateFileStream(name, extension);
        }

        // Overload used when page number is provided.
        public Stream GetStream(string name, string extension, int page)
        {
            // Include page number in the file name to avoid collisions.
            string pageName = $"{name}_page{page}";
            return CreateFileStream(pageName, extension);
        }

        // Helper to create and track the file stream.
        private Stream CreateFileStream(string name, string extension)
        {
            string fileName = $"{name}.{extension}";
            string fullPath = Path.Combine(_networkFolder, fileName);
            // Ensure the directory exists.
            Directory.CreateDirectory(_networkFolder);
            var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            _openedStreams.Add(fileStream);
            return fileStream;
        }

        // Called by Aspose.HTML after writing is finished.
        public void ReleaseStream(Stream stream)
        {
            // Do not dispose here; streams will be disposed in Dispose().
        }

        public void Dispose()
        {
            foreach (var stream in _openedStreams)
            {
                stream?.Dispose();
            }
            _openedStreams.Clear();
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the local EPUB file.
                string epubPath = @"C:\Input\sample.epub";

                // Network folder where JPEG images will be saved.
                string networkFolder = @"\\MyServer\Shared\EpubImages";

                // Open the EPUB file as a stream.
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Configure image save options for JPEG format.
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    // Create the custom network stream provider.
                    using (NetworkStreamProvider provider = new NetworkStreamProvider(networkFolder))
                    {
                        // Perform the conversion; each page will be written to the network location.
                        Converter.ConvertEPUB(epubStream, options, provider);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}