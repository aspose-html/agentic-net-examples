// Load HTML from a stream, modify its DOCTYPE declaration, and write back to a new stream.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare input HTML stream
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello</p></body></html>";
                byte[] htmlBytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
                using (var inputStream = new System.IO.MemoryStream(htmlBytes))
                {
                    // Load document from stream
                    using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
                    {
                        // Create new DOCTYPE
                        var newDoctype = document.CreateDocumentType("html", "", "", "");
                        var oldDoctype = document.Doctype;
                        if (oldDoctype != null)
                        {
                            document.RemoveChild(oldDoctype);
                        }
                        // Insert new DOCTYPE before the root element
                        document.InsertBefore(newDoctype, document.DocumentElement);

                        // Save modified HTML to a file
                        document.Save("modified.html");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }

    // Custom stream provider implementation (kept for completeness, not used in this example)
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
        }
    }
}