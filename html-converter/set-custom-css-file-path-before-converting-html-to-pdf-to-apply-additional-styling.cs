// Set custom CSS file path before converting HTML to PDF to apply additional styling.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string cssPath = "custom.css";
            string pdfPath = "output.pdf";

            // Create sample HTML file
            System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head></head><body><h1>Hello World</h1></body></html>");

            // Create custom CSS file
            System.IO.File.WriteAllText(cssPath, "h1 { color: red; }");

            // Configure Aspose.HTML and set custom CSS
            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)config.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssPath;

            // Load HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            System.Console.WriteLine("PDF created successfully at " + pdfPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}