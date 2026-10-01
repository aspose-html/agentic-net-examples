// Handle conversion exceptions by wrapping Converter.ConvertSVG calls in try‑catch blocks and logging errors.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Directory.GetCurrentDirectory();
            string htmlPath = Path.Combine(outputDir, "sample.html");
            string mhtmlPath = Path.Combine(outputDir, "sample.mhtml");
            string pdfPath = Path.Combine(outputDir, "sample.pdf");
            string jpegPath = Path.Combine(outputDir, "sample.jpg");

            // Create sample HTML content and write to file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Convert HTML string to MHTML file
            string baseUri = "http://example.com";
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, mhtmlOptions, mhtmlPath);
            Console.WriteLine($"HTML converted to MHTML: {mhtmlPath}");

            // Convert MHTML to PDF with retry logic
            ConvertMhtmlToPdfWithRetry(mhtmlPath, pdfPath, 3);
            Console.WriteLine($"MHTML converted to PDF: {pdfPath}");

            // Configure network service with a custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ExcludeHandler());

            // Load document via request and convert to MHTML again (demonstrating overload)
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Aspose.Html.Saving.MHTMLSaveOptions docMhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, docMhtmlOptions, mhtmlPath);
                Console.WriteLine($"Document converted to MHTML: {mhtmlPath}");
            }

            // Convert SVG content to JPEG image
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='blue'/></svg>";
            Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, imgOptions, jpegPath);
            Console.WriteLine($"SVG converted to JPEG: {jpegPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }
                return; // Success
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            // Wait before next attempt
            Thread.Sleep(1000);
        }

        throw lastException ?? new Exception("Conversion failed after all retry attempts.");
    }
}

class ExcludeHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Regex _excludeRegex = new Regex(".*\\.png$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string urlText = context.Request.RequestUri.ToString();
        if (_excludeRegex.IsMatch(urlText))
        {
            return;
        }
        Next(context);
    }
}