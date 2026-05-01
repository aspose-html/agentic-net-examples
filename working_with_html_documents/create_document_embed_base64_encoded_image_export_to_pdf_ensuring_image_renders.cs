// Create a document, embed a base64‑encoded image, and export to PDF ensuring image renders.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace EmbedBase64ImageToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML content with an embedded base64‑encoded PNG image
                string htmlContent = @"
                    <html>
                        <body>
                            <h1>Base64 Image Test</h1>
                            <img src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA
                            AAAFCAYAAACNbyblAAAAHElEQVQI12P4
                            //8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg=="" />
                        </body>
                    </html>";

                // Base URI for the HTML document (empty because resources are embedded)
                string baseUri = "";

                // PDF conversion options (default settings)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert the HTML string to a PDF file
                Converter.ConvertHTML(htmlContent, baseUri, pdfOptions, "output.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}