// Stream validation results to a network socket using a custom TextWriter for remote monitoring.

using System;
using System.IO;
using System.Net.Sockets;

class TimingMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        DateTime startTime = DateTime.UtcNow;
        base.Next(context);
        DateTime endTime = DateTime.UtcNow;
        TimeSpan elapsed = endTime - startTime;
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}

class HeaderMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-Custom-Id"] = Guid.NewGuid().ToString();
        base.Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string baseUri = "http://example.com/";
            string outputPdfPath = "output.pdf";

            // Configure Aspose.HTML with custom message handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimingMessageHandler());
            networkService.MessageHandlers.Add(new HeaderMessageHandler());

            // Convert SVG to PDF
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, pdfOptions, outputPdfPath);

            // Send the generated PDF over TCP
            byte[] payload = File.ReadAllBytes(outputPdfPath);
            using (TcpClient client = new TcpClient("localhost", 9000))
            using (NetworkStream networkStream = client.GetStream())
            {
                networkStream.Write(payload, 0, payload.Length);
                networkStream.Flush();
            }

            // Accessibility validation of a simple HTML document
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello</p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                Aspose.Html.Accessibility.WebAccessibility webAcc = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAcc.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    Console.WriteLine("Accessibility validation result:");
                    Console.WriteLine(sw.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}