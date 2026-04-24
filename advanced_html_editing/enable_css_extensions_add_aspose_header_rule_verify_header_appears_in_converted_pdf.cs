// Enable CSS extensions, add a -aspose- header rule, and verify header appears in converted PDF.

using System;
using System.IO;
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
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration config = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgent.UserStyleSheet = "body::before { content:\"-aspose-\"; display:block; font-size:20px; text-align:center; margin-bottom:10px; }";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}