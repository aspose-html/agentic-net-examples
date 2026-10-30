// Apply FitToContentWidth flag only, producing a PDF where width adapts to longest paragraph.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Sample</title></head><body>" +
                                 "<p>This is a short paragraph.</p>" +
                                 "<p>This is a much longer paragraph that should determine the width of the resulting PDF document when using the FitToContentWidth option.</p>" +
                                 "<p>Another short one.</p>" +
                                 "</body></html>";

            System.IO.File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);

            Console.WriteLine("PDF generated successfully at " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}