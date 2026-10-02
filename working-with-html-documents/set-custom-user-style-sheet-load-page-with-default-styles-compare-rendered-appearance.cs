// Set custom user style sheet, load a page with default styles, and compare rendered appearance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p class='msg'>Hello World</p></body></html>";
            string samplePath = "sample.html";
            File.WriteAllText(samplePath, htmlContent);

            // CSS for custom stylesheet
            string cssContent = ".msg { color: red; font-weight: bold; }";

            // Default configuration (no custom stylesheet)
            Aspose.Html.Configuration defaultConfig = Aspose.Html.Configuration.Create();
            Aspose.Html.HTMLDocument defaultDoc = new Aspose.Html.HTMLDocument(samplePath, defaultConfig);
            string defaultPdfPath = "default.pdf";
            Aspose.Html.Saving.PdfSaveOptions defaultOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(defaultDoc, defaultOptions, defaultPdfPath);

            // Custom configuration with user style sheet
            Aspose.Html.Configuration customConfig = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)customConfig.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssContent;
            Aspose.Html.HTMLDocument customDoc = new Aspose.Html.HTMLDocument(samplePath, customConfig);
            string customPdfPath = "custom.pdf";
            Aspose.Html.Saving.PdfSaveOptions customOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(customDoc, customOptions, customPdfPath);

            // Compare file sizes
            long defaultSize = new FileInfo(defaultPdfPath).Length;
            long customSize = new FileInfo(customPdfPath).Length;
            Console.WriteLine($"Default PDF size: {defaultSize} bytes");
            Console.WriteLine($"Custom PDF size: {customSize} bytes");
            if (defaultSize != customSize)
            {
                Console.WriteLine("The rendered appearance differs due to the custom style sheet.");
            }
            else
            {
                Console.WriteLine("The rendered appearance appears identical.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}