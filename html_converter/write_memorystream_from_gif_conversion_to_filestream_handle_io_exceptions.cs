// Write the MemoryStream obtained from GIF conversion to a FileStream and handle any I/O exceptions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly System.Collections.Generic.List<MemoryStream> _streams = new System.Collections.Generic.List<MemoryStream>();
    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }
    public Stream GetStream(string path, string extension, int bufferSize)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }
    public void ReleaseStream(Stream stream) { }
    public void Dispose()
    {
        foreach (var ms in _streams) ms.Dispose();
        _streams.Clear();
    }
    public MemoryStream GetFirstStream()
    {
        return _streams.Count > 0 ? _streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            using (var epubStream = File.OpenRead("sample.epub"))
            using (var provider = new MemoryStreamProvider())
            {
                var options = new ImageSaveOptions(ImageFormat.Gif);
                Converter.ConvertEPUB(epubStream, options, provider);
                var gifStream = provider.GetFirstStream();
                if (gifStream != null)
                {
                    gifStream.Position = 0;
                    using (var fileStream = new FileStream("output.gif", FileMode.Create, FileAccess.Write))
                    {
                        gifStream.CopyTo(fileStream);
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}