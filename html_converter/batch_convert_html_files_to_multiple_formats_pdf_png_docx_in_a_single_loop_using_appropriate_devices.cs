// Batch convert HTML files to multiple formats (PDF, PNG, DOCX) in a single loop using appropriate devices.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string pdfFolder = "OutputPdf";
            string pngFolder = "OutputPng";
            string docxFolder = "OutputDocx";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(pdfFolder);
            Directory.CreateDirectory(pngFolder);
            Directory.CreateDirectory(docxFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    string pdfPath = Path.Combine(pdfFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    PdfDevice pdfDevice = new PdfDevice(pdfPath);
                    document.RenderTo(pdfDevice);

                    string pngPath = Path.Combine(pngFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".png");
                    ImageSaveOptions pngOptions = new ImageSaveOptions(ImageFormat.Png);
                    Converter.ConvertHTML(document, pngOptions, pngPath);

                    string docxPath = Path.Combine(docxFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".docx");
                    DocSaveOptions docOptions = new DocSaveOptions();
                    Converter.ConvertHTML(document, docOptions, docxPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}