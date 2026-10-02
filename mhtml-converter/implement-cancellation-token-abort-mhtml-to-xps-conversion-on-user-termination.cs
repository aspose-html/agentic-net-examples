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
            string inputPath = "sample.mht";
            string outputPath = "output.xps";

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                // Cancel after 2 seconds to simulate user termination request
                Task.Delay(TimeSpan.FromSeconds(2)).ContinueWith(_ => cts.Cancel());

                ConvertMhtmlToXps(inputPath, outputPath, cts.Token).GetAwaiter().GetResult();
                Console.WriteLine("Conversion completed successfully.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Conversion was cancelled by the user.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertMhtmlToXps(string inputPath, string outputPath, CancellationToken token)
    {
        // Check for cancellation before starting the conversion
        token.ThrowIfCancellationRequested();

        using (FileStream stream = File.OpenRead(inputPath))
        {
            XpsSaveOptions options = new XpsSaveOptions();

            // Perform conversion in a separate task to allow cancellation monitoring
            await Task.Run(() =>
            {
                // Re-check cancellation inside the task
                token.ThrowIfCancellationRequested();

                // Perform the actual conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }, token);
        }
    }
}