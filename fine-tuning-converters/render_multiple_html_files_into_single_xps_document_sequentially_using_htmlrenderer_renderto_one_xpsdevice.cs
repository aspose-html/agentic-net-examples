// Render multiple HTML files into a single XPS document by sequentially calling HtmlRenderer.RenderTo on one XpsDevice.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            System.IO.Directory.CreateDirectory(outputDir);

            string[] inputFiles = new string[]
            {
                System.IO.Path.Combine(outputDir, "input1.html"),
                System.IO.Path.Combine(outputDir, "input2.html"),
                System.IO.Path.Combine(outputDir, "input3.html")
            };

            string[] htmlContents = new string[]
            {
                "<html><body><h1>First Document</h1></body></html>",
                "<html><body><h1>Second Document</h1></body></html>",
                "<html><body><h1>Third Document</h1></body></html>"
            };

            for (int i = 0; i < inputFiles.Length; i++)
            {
                System.IO.File.WriteAllText(inputFiles[i], htmlContents[i]);
            }

            string outputPath = System.IO.Path.Combine(outputDir, "combined.xps");

            using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(outputPath))
            {
                foreach (string file in inputFiles)
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(file))
                    {
                        document.RenderTo(device);
                    }
                }
            }

            Console.WriteLine("XPS document created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}