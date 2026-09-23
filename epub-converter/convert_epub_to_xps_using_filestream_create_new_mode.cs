// Convert an EPUB file to XPS by writing the output using FileStream with create‑new mode.

namespace Example
{
    class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
    {
        public System.Collections.Generic.List<System.IO.MemoryStream> Streams { get; } = new System.Collections.Generic.List<System.IO.MemoryStream>();

        public System.IO.Stream GetStream(string name, string extension)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        public System.IO.Stream GetStream(string name, string extension, int page)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
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
            foreach (System.IO.MemoryStream ms in Streams)
            {
                ms.Dispose();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "output.xps";

                using (System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath))
                {
                    MemoryStreamProvider provider = new MemoryStreamProvider();
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    System.IO.MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0;

                    using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}