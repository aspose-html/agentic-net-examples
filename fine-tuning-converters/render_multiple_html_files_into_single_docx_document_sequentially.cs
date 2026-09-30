// Render multiple HTML files into a single DOCX document by sequentially invoking HtmlRenderer.RenderTo on a DocDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "Combined.docx");

            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);

            string[] inputs = new string[] { "sample1.html", "sample2.html", "sample3.html" };
            for (int i = 0; i < inputs.Length; i++)
            {
                string path = inputs[i];
                if (!System.IO.File.Exists(path))
                {
                    string html = $"<html><body><h1>Sample {i + 1}</h1><p>This is sample HTML file {i + 1}.</p></body></html>";
                    System.IO.File.WriteAllText(path, html);
                }
            }

            foreach (string inputPath in inputs)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    document.RenderTo(device);
                }
            }

            device.Dispose();

            Console.WriteLine("HTML files have been rendered into DOCX: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}