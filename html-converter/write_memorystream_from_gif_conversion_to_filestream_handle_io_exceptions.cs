// Write the MemoryStream obtained from GIF conversion to a FileStream and handle any I/O exceptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    private readonly List<System.IO.MemoryStream> _streams = new List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams in this example
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
        _streams.Clear();
    }

    public System.IO.MemoryStream GetFirstStream()
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
            string epubPath = "sample.epub";
            string outputPath = "output.gif";

            // Ensure the input file exists; otherwise, an exception will be thrown
            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    System.IO.MemoryStream gifStream = provider.GetFirstStream();
                    if (gifStream != null)
                    {
                        gifStream.Position = 0;
                        try
                        {
                            using (System.IO.FileStream file = System.IO.File.Create(outputPath))
                            {
                                gifStream.CopyTo(file);
                            }
                            System.Console.WriteLine("GIF image saved to: " + outputPath);
                        }
                        catch (System.IO.IOException ioEx)
                        {
                            System.Console.WriteLine("I/O error while writing the GIF file: " + ioEx.Message);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No GIF stream was generated.");
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}