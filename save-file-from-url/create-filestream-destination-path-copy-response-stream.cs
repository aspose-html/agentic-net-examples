// Create a FileStream for the destination path and copy the response stream to it.

using System;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
{
    public System.Collections.Generic.List<System.IO.MemoryStream> Streams = new System.Collections.Generic.List<System.IO.MemoryStream>();

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
        // No action needed
    }

    public void Dispose()
    {
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Prepare provider and options
            var provider = new MemoryStreamProvider();
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF using the provider
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Retrieve the generated stream
            var resultStream = provider.Streams[0];
            resultStream.Position = 0;

            // Copy the result stream to a file
            string outputPath = "output.pdf";
            using (var fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                resultStream.CopyTo(fileStream);
            }

            Console.WriteLine("Conversion completed. PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}