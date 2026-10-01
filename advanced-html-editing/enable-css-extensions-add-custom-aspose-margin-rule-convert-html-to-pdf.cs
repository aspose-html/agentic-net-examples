// Enable CSS extensions, add a custom -aspose- margin rule, then convert the HTML to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><div class='custom'>Hello Aspose HTML</div></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Create configuration and enable custom CSS rule
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = ".custom { -aspose-margin: 20px; }";

            // Load HTML document with configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Set up PDF save options with page size and margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}