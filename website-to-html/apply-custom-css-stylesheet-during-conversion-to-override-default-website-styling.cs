// Apply a custom CSS stylesheet during conversion to override the default website styling.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputHtmlPath = "sample.html";
            string cssPath = "custom.css";
            string outputPdfPath = "output.pdf";

            // Create sample HTML file
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<html><head></head><body><h1>Hello World</h1></body></html>");
            }

            // Create custom CSS file
            if (!File.Exists(cssPath))
            {
                File.WriteAllText(cssPath, "h1 { color: red; }");
            }

            // Read CSS content
            string cssContent = File.ReadAllText(cssPath);

            // Configure Aspose.HTML with custom stylesheet
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssContent;

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF applying the custom CSS
            Aspose.Html.Converters.Converter.ConvertHTML(
                new Aspose.Html.Url(inputHtmlPath),
                configuration,
                options,
                outputPdfPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}