// Set custom user style sheet, load a page with default styles, and compare rendered appearance.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello, world!</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Output paths
            string defaultPdf = "default.pdf";
            string customPdf = "custom.pdf";

            // ---------- Render with default styles ----------
            Aspose.Html.Configuration defaultConfig = Aspose.Html.Configuration.Create();
            Aspose.Html.HTMLDocument defaultDoc = new Aspose.Html.HTMLDocument(inputPath, defaultConfig);
            Aspose.Html.Saving.PdfSaveOptions defaultOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(defaultDoc, defaultOptions, defaultPdf);

            // ---------- Render with custom user style sheet ----------
            Aspose.Html.Configuration customConfig = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)customConfig.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = "p { color: red; font-weight: bold; }";
            Aspose.Html.HTMLDocument customDoc = new Aspose.Html.HTMLDocument(inputPath, customConfig);
            Aspose.Html.Saving.PdfSaveOptions customOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(customDoc, customOptions, customPdf);

            // Simple comparison: file sizes
            long defaultSize = new FileInfo(defaultPdf).Length;
            long customSize = new FileInfo(customPdf).Length;
            Console.WriteLine($"Default PDF size: {defaultSize} bytes");
            Console.WriteLine($"Custom PDF size: {customSize} bytes");
            Console.WriteLine(customSize != defaultSize ? "Custom style sheet applied, resulting PDF differs." : "No difference detected.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}