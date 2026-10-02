// Apply FitToContentWidth flag only, producing a PDF where width adapts to longest paragraph.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "sample.html";
                string pdfPath = "output.pdf";

                string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>FitToContentWidth Example</title></head><body>" +
                    "<p>This is a short paragraph.</p>" +
                    "<p>This is a much longer paragraph that should determine the width of the resulting PDF document when the FitToContentWidth option is applied.</p>" +
                    "<p>Another short one.</p>" +
                    "</body></html>";

                System.IO.File.WriteAllText(htmlPath, htmlContent);

                var document = new Aspose.Html.HTMLDocument(htmlPath);
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth;

                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine("PDF generated successfully at " + pdfPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}