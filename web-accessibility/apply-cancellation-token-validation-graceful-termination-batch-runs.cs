// Apply a cancellation token to the validation process to allow graceful termination during long batch runs.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample input folder and file
            string inputFolder = "InputHtml";
            Directory.CreateDirectory(inputFolder);
            string sampleFile = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleFile))
            {
                File.WriteAllText(sampleFile, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
            }

            // Cancellation token that triggers after 10 seconds
            using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            {
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
                foreach (string filePath in htmlFiles)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation cancelled before processing file: " + Path.GetFileName(filePath));
                        break;
                    }

                    ValidateHtml(filePath, cts.Token);
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Validation was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ValidateHtml(string filePath, CancellationToken token)
    {
        // Load the HTML document (simulating validation)
        Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath, configuration))
        {
            // Simple validation logic: access the title
            string title = document.Title;
            Console.WriteLine($"Validated '{Path.GetFileName(filePath)}' - Title: {title}");
        }

        // Check for cancellation after processing
        token.ThrowIfCancellationRequested();
    }
}