// Use a MemoryStream to temporarily hold the response data before writing to disk for validation.

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
            string htmlPath = "input.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                System.IO.MemoryStream resultStream = provider.Streams[0];
                resultStream.Position = 0;

                using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    resultStream.CopyTo(fileStream);
                }
            }

            document.Dispose();
            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}