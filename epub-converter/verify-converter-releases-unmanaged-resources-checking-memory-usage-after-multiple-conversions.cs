// Verify that the Converter object releases unmanaged resources by checking memory usage after multiple conversions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
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
    static void Main()
    {
        try
        {
            const string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            const string baseUri = "about:blank";
            const string outputPathTemplate = "output_{0}.pdf";

            long initialMemory = System.GC.GetTotalMemory(true);
            System.Console.WriteLine($"Initial memory: {initialMemory}");

            for (int i = 0; i < 10; i++)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                CustomStreamProvider provider = new CustomStreamProvider();
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                System.IO.MemoryStream resultStream = provider.Streams[0];
                resultStream.Position = 0;

                string outputPath = string.Format(outputPathTemplate, i);
                using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    resultStream.CopyTo(fileStream);
                }

                provider.Dispose();
                document.Dispose();

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

                long afterMemory = System.GC.GetTotalMemory(true);
                System.Console.WriteLine($"Iteration {i + 1}, memory: {afterMemory}");
            }

            long finalMemory = System.GC.GetTotalMemory(true);
            System.Console.WriteLine($"Final memory: {finalMemory}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}