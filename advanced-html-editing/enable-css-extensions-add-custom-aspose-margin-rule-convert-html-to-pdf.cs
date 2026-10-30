// Enable CSS extensions, add a custom -aspose- margin rule, then convert the HTML to PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            string htmlPath = "input.html";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Create configuration and enable CSS extensions via user style sheet
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "-aspose-margin: 20px;";

            // Load HTML document with configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Set up PDF save options with page size and custom margin
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(20, 20, 20, 20);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            // Convert to PDF
            string pdfPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}