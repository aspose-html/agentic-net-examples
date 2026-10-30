// Render multiple HTML files into a single DOCX document by sequentially invoking HtmlRenderer.RenderTo on a DocDevice.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "HTMLInputs");
            Directory.CreateDirectory(outputDir);

            string[] inputFiles = new string[]
            {
                Path.Combine(outputDir, "input1.html"),
                Path.Combine(outputDir, "input2.html")
            };

            File.WriteAllText(inputFiles[0], "<html><body><h1>First Document</h1><p>Hello from the first HTML file.</p></body></html>");
            File.WriteAllText(inputFiles[1], "<html><body><h1>Second Document</h1><p>Hello from the second HTML file.</p></body></html>");

            // Output DOCX path
            string outputDocx = Path.Combine(Directory.GetCurrentDirectory(), "CombinedDocument.docx");

            // Create Doc rendering options and device
            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputDocx);

            // Render each HTML document sequentially into the same DOCX
            foreach (string htmlPath in inputFiles)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    document.RenderTo(device);
                }
            }

            // Dispose the device to finalize the DOCX file
            device.Dispose();

            Console.WriteLine("Successfully combined HTML files into DOCX: " + outputDocx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}