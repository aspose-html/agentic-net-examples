// Convert an HTML file to PDF using PdfRenderingOptions to set custom page size and margins.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, PDF!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));

            Aspose.Html.Drawing.Margin margins = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margins);

            options.PageSetup.AnyPage = page;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            document.RenderTo(device);

            device.Dispose();
            document.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}