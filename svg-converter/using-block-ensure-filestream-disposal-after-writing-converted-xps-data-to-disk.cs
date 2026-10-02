// Use a using block to ensure FileStream disposal after writing converted XPS data to disk.

namespace Example
{
    class Program
    {
        static void Main()
        {
            string htmlPath = "sample.html";
            string outputPath = "output.xps";

            try
            {
                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, provider);
                    if (provider.Streams.Count > 0)
                    {
                        System.IO.MemoryStream xpsStream = provider.Streams[0];
                        xpsStream.Position = 0;
                        using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        {
                            xpsStream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Conversion failed: " + ex.Message);
            }
        }
    }

    class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
    {
        public System.Collections.Generic.List<System.IO.MemoryStream> Streams { get; } = new System.Collections.Generic.List<System.IO.MemoryStream>();

        public System.IO.Stream GetStream(string name, string extension)
        {
            var ms = new System.IO.MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public System.IO.Stream GetStream(string name, string extension, int page)
        {
            var ms = new System.IO.MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public void ReleaseStream(System.IO.Stream stream)
        {
            if (stream != null)
            {
                stream.Flush();
            }
        }

        public void Dispose()
        {
            foreach (var s in Streams)
            {
                s.Dispose();
            }
        }
    }
}