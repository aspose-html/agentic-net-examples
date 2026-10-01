// Implement a cancellation token that aborts MHTML to XPS conversion when the user requests termination.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML Content</h1></body></html>");
            }

            var cts = new CancellationTokenSource();

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
                Console.WriteLine("Cancellation requested by user.");
            };

            Task conversionTask = Task.Run(() => ConvertMhtmlToXps(inputPath, outputPath, cts.Token), cts.Token);

            conversionTask.Wait();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Conversion was canceled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToXps(string inputPath, string outputPath, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        using (FileStream stream = File.OpenRead(inputPath))
        {
            XpsSaveOptions options = new XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }

        token.ThrowIfCancellationRequested();
    }
}