// Save the document as PNG using HTMLDocument.Save with ImageSaveOptions specifying PNG format.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, PNG!</h1></body></html>";
                string outputPath = "output.png";

                var streamProvider = new MemoryStreamProvider();

                var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, streamProvider);

                if (streamProvider.Streams.Count > 0)
                {
                    var memoryStream = streamProvider.Streams[0];
                    memoryStream.Position = 0;
                    using (var fileStream = System.IO.File.Create(outputPath))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                }
                else
                {
                    System.Console.WriteLine("No streams were generated.");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }

    class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
    {
        private readonly System.Collections.Generic.List<System.IO.MemoryStream> _streams = new System.Collections.Generic.List<System.IO.MemoryStream>();

        public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;

        public System.IO.Stream GetStream(string name, string extension)
        {
            var ms = new System.IO.MemoryStream();
            _streams.Add(ms);
            return ms;
        }

        public System.IO.Stream GetStream(string name, string extension, int page)
        {
            var ms = new System.IO.MemoryStream();
            _streams.Add(ms);
            return ms;
        }

        public void ReleaseStream(System.IO.Stream stream)
        {
            // No action needed
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
}