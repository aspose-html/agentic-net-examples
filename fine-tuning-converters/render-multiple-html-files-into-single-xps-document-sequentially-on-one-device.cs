// Render multiple HTML files into a single XPS document by sequentially calling HtmlRenderer.RenderTo on one XpsDevice.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            // Create sample HTML files
            string[] inputFiles = new string[]
            {
                System.IO.Path.Combine(outputDir, "input1.html"),
                System.IO.Path.Combine(outputDir, "input2.html")
            };
            string html1 = "<!DOCTYPE html><html><body><h1>First Document</h1></body></html>";
            string html2 = "<!DOCTYPE html><html><body><h1>Second Document</h1></body></html>";
            System.IO.File.WriteAllText(inputFiles[0], html1);
            System.IO.File.WriteAllText(inputFiles[1], html2);

            // Create XPS device
            string outputPath = System.IO.Path.Combine(outputDir, "combined.xps");
            using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(outputPath))
            {
                // Render each HTML document sequentially to the same XPS device
                foreach (string filePath in inputFiles)
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath))
                    {
                        document.RenderTo(device);
                    }
                }
            }

            Console.WriteLine("Combined XPS document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}