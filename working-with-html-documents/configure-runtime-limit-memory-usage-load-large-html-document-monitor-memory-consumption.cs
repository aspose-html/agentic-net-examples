// Configure runtime to limit memory usage, load a large HTML document, and monitor memory consumption.

sealed class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
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
    public void ReleaseStream(System.IO.Stream stream)
    {
        if (stream != null) stream.Flush();
    }
    public void Dispose()
    {
        foreach (var s in _streams) s.Dispose();
    }
    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            // Configure runtime (e.g., JavaScript timeout to limit execution)
            var config = new Aspose.Html.Configuration();
            var runtimeService = config.GetService<Aspose.Html.Services.IRuntimeService>();
            runtimeService.JavaScriptTimeout = System.TimeSpan.FromSeconds(5);

            // Generate large HTML content
            var sb = new System.Text.StringBuilder();
            sb.Append("<!DOCTYPE html><html><head><title>Large Document</title></head><body>");
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("<div>Line ").Append(i).Append("</div>");
            }
            sb.Append("</body></html>");
            string largeHtml = sb.ToString();

            // Memory before loading
            long before = System.GC.GetTotalMemory(true);
            System.Console.WriteLine($"Memory before loading: {before / 1024} KB");

            // Load document with configuration
            var document = new Aspose.Html.HTMLDocument(largeHtml, "about:blank", config);

            // Memory after loading
            long after = System.GC.GetTotalMemory(true);
            System.Console.WriteLine($"Memory after loading: {after / 1024} KB");
            System.Console.WriteLine($"Memory increase: {(after - before) / 1024} KB");

            // Convert to image using in‑memory provider
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            var provider = new MemoryStreamProvider();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            var imageStream = provider.Streams[0];
            imageStream.Position = 0;
            System.Console.WriteLine($"Generated image size: {imageStream.Length} bytes");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}