// Render an HTML document to PDF while embedding a custom page header defined in CSS.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><style>" +
                          "@page { margin: 0; }" +
                          "header { position: fixed; top: 0; left: 0; right: 0; height: 50px; background: #f0f0f0; text-align: center; line-height: 50px; font-weight: bold; }" +
                          "body { margin-top: 60px; }" +
                          "</style></head><body>" +
                          "<header>Custom Header</header>" +
                          "<div>Page content goes here.</div>" +
                          "</body></html>";
            string baseUri = "file:///";
            string pdfPath = "output.pdf";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            document.Save("output.html");
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath);
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}