// Batch convert a folder of HTML files to PDF, applying the same conversion options to each.

using System;

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        System.Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
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
        if (stream != null) { stream.Flush(); }
    }

    public void Dispose()
    {
        foreach (var ms in Streams) { ms.Dispose(); }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string inputFolder = "Input";
            string outputFolder = "Output";
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file
            string htmlPath = System.IO.Path.Combine(inputFolder, "sample.html");
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");

            // Convert HTML to JPEG
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                string jpegPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, jpegPath);
            }

            // Render multiple HTML documents to a single PDF
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument("<html><body><p>Doc1</p></body></html>", "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument("<html><body><p>Doc2</p></body></html>", "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument("<html><body><p>Doc3</p></body></html>", "about:blank");
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            string renderedPdfPath = System.IO.Path.Combine(outputFolder, "rendered.pdf");
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfRenderOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfRenderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            pdfRenderOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfRenderOptions, renderedPdfPath);
            renderer.Render(pdfDevice, document1, document2, document3);
            document1.Dispose();
            document2.Dispose();
            document3.Dispose();

            // Network logging conversion
            Aspose.Html.Configuration netConfig = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = netConfig.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new LogHandler());
            using (Aspose.Html.HTMLDocument netDoc = new Aspose.Html.HTMLDocument(htmlPath, netConfig))
            {
                string netPdfPath = System.IO.Path.ChangeExtension(htmlPath, ".net.pdf");
                Aspose.Html.Saving.PdfSaveOptions netPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(netDoc, netPdfOptions, netPdfPath);
            }

            // Create a sample SVG file
            string svgPath = System.IO.Path.Combine(inputFolder, "sample.svg");
            System.IO.File.WriteAllText(svgPath, "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>");

            // Convert SVG to PDF with custom page setup
            string svgPdfPath = System.IO.Path.Combine(outputFolder, "sample_svg.pdf");
            Aspose.Html.Saving.PdfSaveOptions svgPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            svgPdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, svgPdfOptions, svgPdfPath);

            // Convert Markdown to PDF
            string markdownPath = System.IO.Path.Combine(inputFolder, "sample.md");
            System.IO.File.WriteAllText(markdownPath, "# Hello Markdown\nThis is a test.");
            Aspose.Html.HTMLDocument mdDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);
            string mdPdfPath = System.IO.Path.Combine(outputFolder, "sample_md.pdf");
            Aspose.Html.Saving.PdfSaveOptions mdPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            mdPdfOptions.HorizontalResolution = 300;
            mdPdfOptions.VerticalResolution = 300;
            mdPdfOptions.BackgroundColor = System.Drawing.Color.White;
            Aspose.Html.Converters.Converter.ConvertHTML(mdDoc, mdPdfOptions, mdPdfPath);
            mdDoc.Dispose();

            // In‑memory PDF conversion using a custom stream provider
            Aspose.Html.HTMLDocument memDoc = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions memOptions = new Aspose.Html.Saving.PdfSaveOptions();
            CustomStreamProvider streamProvider = new CustomStreamProvider();
            Aspose.Html.Converters.Converter.ConvertHTML(memDoc, memOptions, streamProvider);
            if (streamProvider.Streams.Count > 0)
            {
                var memory = streamProvider.Streams[0];
                memory.Position = 0;
                string memPdfPath = System.IO.Path.Combine(outputFolder, "memory.pdf");
                using (var fs = System.IO.File.Create(memPdfPath))
                {
                    memory.CopyTo(fs);
                }
            }
            memDoc.Dispose();
            streamProvider.Dispose();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}