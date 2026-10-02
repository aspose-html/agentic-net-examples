// Batch convert HTML files to PDF, adding page numbers via drawing API after rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html", System.IO.SearchOption.TopDirectoryOnly);
            if (htmlFiles.Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><h1>Sample Document</h1></body></html>");
                htmlFiles = new string[] { samplePath };
            }

            int pageNumber = 1;
            foreach (string htmlPath in htmlFiles)
            {
                // Load HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Create canvas for page number
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;
                canvas.Height = 1000;
                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillText($"Page {pageNumber}", 10, 20, 0);

                // Append canvas to body
                document.Body.AppendChild(canvas);

                // Prepare PDF save options with page size matching canvas
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 1000));

                // Define output PDF path
                string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(htmlPath);
                string pdfPath = System.IO.Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

                pageNumber++;
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}