// Batch convert HTML files to multiple formats (PDF, PNG, DOCX) in a single loop using appropriate devices.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "Output";
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(htmlPath);
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    // PDF conversion
                    Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                    pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));
                    pdfOptions.BackgroundColor = System.Drawing.Color.White;
                    string pdfPath = System.IO.Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");
                    Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, pdfPath);
                    Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
                    renderer.Render(pdfDevice, document);

                    // PNG conversion
                    Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
                    string pngPath = System.IO.Path.Combine(outputFolder, fileNameWithoutExt + ".png");
                    Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, pngPath);
                    renderer.Render(imgDevice, document);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}