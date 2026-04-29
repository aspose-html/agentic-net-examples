// Create a method that accepts an SVG path and returns a MemoryStream containing the XPS result.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

namespace SvgToXpsExample
{
    // In‑memory stream provider that captures generated streams
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        public Stream GetStream(string name, string contentType)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public Stream GetStream(string name, string contentType, int bufferSize)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public void ReleaseStream(Stream stream)
        {
            if (stream != null)
                stream.Position = 0;
        }

        public void Dispose()
        {
            foreach (var ms in Streams)
                ms.Dispose();
        }
    }

    class Program
    {
        // Converts an SVG file to XPS and returns the result as a MemoryStream
        static MemoryStream ConvertSvgToXps(string svgPath)
        {
            var options = new XpsSaveOptions();
            using (var provider = new MemoryStreamProvider())
            {
                // Perform conversion; result is written to the provider's stream
                Converter.ConvertSVG(svgPath, options, provider);
                // Retrieve the first generated stream
                var xpsStream = provider.Streams[0];
                xpsStream.Position = 0;
                return xpsStream;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Example SVG file path
                string svgFilePath = "example.svg";

                // Convert and obtain XPS in memory
                MemoryStream xpsResult = ConvertSvgToXps(svgFilePath);

                // For demonstration, write the XPS to a file
                using (var file = File.Create("output.xps"))
                {
                    xpsResult.CopyTo(file);
                }

                Console.WriteLine("SVG successfully converted to XPS.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}