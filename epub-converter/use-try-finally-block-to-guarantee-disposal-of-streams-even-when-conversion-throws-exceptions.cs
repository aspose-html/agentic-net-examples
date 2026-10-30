// Use a try‑finally block to guarantee disposal of streams even when conversion throws exceptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputXps";
            System.IO.Directory.CreateDirectory(outputDir);
            string[] files = System.IO.Directory.GetFiles(inputDir, "*.epub");
            foreach (string inputPath in files)
            {
                try
                {
                    System.IO.Stream inputStream = null;
                    CustomStreamProvider streamProvider = null;
                    try
                    {
                        inputStream = System.IO.File.OpenRead(inputPath);
                        streamProvider = new CustomStreamProvider();
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, streamProvider);
                        System.IO.MemoryStream resultStream = streamProvider.Streams[0];
                        resultStream.Position = 0;
                        string outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                        using (System.IO.Stream output = System.IO.File.Create(outputPath))
                        {
                            resultStream.CopyTo(output);
                        }
                    }
                    finally
                    {
                        if (inputStream != null)
                        {
                            inputStream.Dispose();
                        }
                        if (streamProvider != null)
                        {
                            streamProvider.Dispose();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Error processing " + System.IO.Path.GetFileName(inputPath) + ": " + ex.Message);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Fatal error: " + ex.Message);
        }
    }
}