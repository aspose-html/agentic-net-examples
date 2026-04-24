// Allow user to cancel batch extraction via a CancellationToken source.

using System;
using System.IO;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input";
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            string[] files = Directory.GetFiles(inputDir, "*.html");
            using var cancellationSource = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                cancellationSource.Cancel();
                e.Cancel = true;
            };
            using var renderer = new HtmlRenderer();
            foreach (string inputPath in files)
            {
                if (cancellationSource.Token.IsCancellationRequested)
                    break;
                using var document = new HTMLDocument(inputPath);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                using var device = new PdfDevice(outputPath);
                renderer.Render(device, cancellationSource.Token, document);
                Console.WriteLine($"Converted: {Path.GetFileName(inputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}