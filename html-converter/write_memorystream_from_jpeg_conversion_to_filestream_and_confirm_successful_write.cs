// Write the MemoryStream obtained from JPEG conversion to a FileStream and confirm successful write.

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    private readonly System.Collections.Generic.List<System.IO.MemoryStream> _streams = new System.Collections.Generic.List<System.IO.MemoryStream>();
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
    public void ReleaseStream(System.IO.Stream stream) { }
    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
    }
    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;
}

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<h1>Convert HTML to JPG File Format!</h1>";
            var document = new Aspose.Html.HTMLDocument(html, ".");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                if (provider.Streams.Count == 0)
                {
                    System.Console.WriteLine("No streams were generated.");
                    return;
                }
                var memoryStream = provider.Streams[0];
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                string outputDir = "output";
                System.IO.Directory.CreateDirectory(outputDir);
                string outputPath = System.IO.Path.Combine(outputDir, "stream-provider.jpg");
                using (var fileStream = System.IO.File.Create(outputPath))
                {
                    memoryStream.CopyTo(fileStream);
                }
                System.Console.WriteLine($"JPEG image saved successfully to '{outputPath}'.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}