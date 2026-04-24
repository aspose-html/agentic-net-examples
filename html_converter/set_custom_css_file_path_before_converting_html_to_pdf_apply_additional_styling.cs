// Set custom CSS file path before converting HTML to PDF to apply additional styling.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPdfWithCustomCss
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the source HTML, CSS file and the output PDF
                string htmlPath = "input.html";
                string cssPath = "styles.css";
                string pdfPath = "output.pdf";

                // Load the CSS content from the external file
                string cssContent = File.ReadAllText(cssPath);

                // Create a configuration and set the user stylesheet to the loaded CSS
                using (Configuration configuration = Configuration.Create())
                {
                    IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
                    userAgentService.UserStyleSheet = cssContent;

                    // Load the HTML document with the configuration that includes the custom CSS
                    HTMLDocument document = new HTMLDocument(htmlPath, configuration);

                    // Prepare PDF save options (default settings)
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Convert the HTML document to PDF applying the custom stylesheet
                    Converter.ConvertHTML(document, options, pdfPath);
                }

                Console.WriteLine("PDF generated successfully at: " + pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}