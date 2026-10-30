// Implement a cancellation token that aborts MHTML to XPS conversion when the user requests termination.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.xps";

            // Ensure a sample input file exists (placeholder content)
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Placeholder MHTML content");
            }

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                // Simulate a user cancellation after a short delay (optional)
                Task.Run(async () =>
                {
                    await Task.Delay(500);
                    cts.Cancel();
                });

                ConvertMhtmlToXps(inputPath, outputPath, cts.Token);
                Console.WriteLine("Conversion completed successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Conversion was canceled by the user.");
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
            // No direct cancellation support in ConvertMHTML, so we check token before call
            token.ThrowIfCancellationRequested();

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
    }
}