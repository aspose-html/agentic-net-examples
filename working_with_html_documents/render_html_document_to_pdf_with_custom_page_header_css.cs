// Render an HTML document to PDF while embedding a custom page header defined in CSS.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering.Pdf;

namespace HtmlToPdfHeader
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputPath = "output.pdf";
                HTMLDocument document = new HTMLDocument();

                Element style = document.CreateElement("style");
                style.InnerHTML = "header { position: fixed; top: 0; left: 0; right: 0; height: 50px; background-color: #f0f0f0; text-align: center; line-height: 50px; font-weight: bold; } body { margin-top: 60px; }";
                document.Body.AppendChild(style);

                Element header = document.CreateElement("header");
                header.InnerHTML = "Custom Page Header";
                document.Body.AppendChild(header);

                Element paragraph = document.CreateElement("p");
                paragraph.InnerHTML = "This is a sample paragraph to demonstrate PDF rendering with a custom header.";
                document.Body.AppendChild(paragraph);

                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 0;
                canvas.Height = 0;
                document.Body.AppendChild(canvas);

                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}