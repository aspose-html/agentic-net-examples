// Convert an HTML file to PDF and set background color to light blue for branding purposes.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Desired output PDF file path
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set PDF rendering options with a light blue background
            PdfRenderingOptions options = new PdfRenderingOptions()
            {
                BackgroundColor = Color.LightBlue
            };

            // Create a PDF device with the options and output path
            PdfDevice device = new PdfDevice(options, pdfPath);

            // Render the HTML document to PDF
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}