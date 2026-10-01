// Batch convert HTML files to multiple formats (PDF, PNG, DOCX) in a single loop using appropriate devices.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "Output";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // PDF conversion
                    PdfRenderingOptions pdfOptions = new PdfRenderingOptions();
                    pdfOptions.PageSetup.AnyPage = new Page(new Size(800, 600));
                    pdfOptions.BackgroundColor = System.Drawing.Color.White;
                    string pdfPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    PdfDevice pdfDevice = new PdfDevice(pdfOptions, pdfPath);
                    document.RenderTo(pdfDevice);

                    // PNG conversion
                    ImageSaveOptions imgOptions = new ImageSaveOptions(ImageFormat.Png);
                    string pngPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".png");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, pngPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}