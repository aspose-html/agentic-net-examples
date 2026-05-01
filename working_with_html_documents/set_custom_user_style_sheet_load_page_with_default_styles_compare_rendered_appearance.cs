// Set custom user style sheet, load a page with default styles, and compare rendered appearance.

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
            string htmlPath = "input.html";
            string defaultPdf = "default.pdf";
            string styledPdf = "styled.pdf";
            string css = "h1 { color: red; } p { font-size: 20px; }";

            // Render without custom stylesheet
            using (Configuration configDefault = new Configuration())
            {
                HTMLDocument docDefault = new HTMLDocument(htmlPath, configDefault);
                PdfSaveOptions optionsDefault = new PdfSaveOptions();
                Converter.ConvertHTML(docDefault, optionsDefault, defaultPdf);
            }

            // Render with custom stylesheet
            using (Configuration configStyled = new Configuration())
            {
                IUserAgentService userAgent = configStyled.GetService<IUserAgentService>();
                userAgent.UserStyleSheet = css;

                HTMLDocument docStyled = new HTMLDocument(htmlPath, configStyled);
                PdfSaveOptions optionsStyled = new PdfSaveOptions();
                Converter.ConvertHTML(docStyled, optionsStyled, styledPdf);
            }

            // Simple comparison of file sizes
            long sizeDefault = new FileInfo(defaultPdf).Length;
            long sizeStyled = new FileInfo(styledPdf).Length;
            Console.WriteLine($"Default PDF size: {sizeDefault} bytes");
            Console.WriteLine($"Styled PDF size: {sizeStyled} bytes");
            Console.WriteLine(sizeDefault == sizeStyled
                ? "Rendered appearance appears identical (size match)."
                : "Rendered appearance differs (size mismatch).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}