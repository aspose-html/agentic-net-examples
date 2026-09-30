// Render an MHTML document to PDF with a custom page orientation set to Portrait for vertical layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string outputPath = "output.pdf";

            if (!File.Exists(sourcePath))
            {
                string htmlContent = "<html><body><h1>Hello, MHTML!</h1></body></html>";
                File.WriteAllText(sourcePath, htmlContent);
            }

            using (FileStream stream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(595, 842) // A4 portrait dimensions
                );

                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
                {
                    Aspose.Html.Rendering.MhtmlRenderer renderer = new Aspose.Html.Rendering.MhtmlRenderer();
                    renderer.Render(device, stream);
                }
            }

            Console.WriteLine("MHTML has been successfully rendered to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}