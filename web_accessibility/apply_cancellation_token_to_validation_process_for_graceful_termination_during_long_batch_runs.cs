// Apply a cancellation token to the validation process to allow graceful termination during long batch runs.

using System;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            using var cts = new CancellationTokenSource();
            // Cancel after 30 seconds to allow graceful termination
            cts.CancelAfter(TimeSpan.FromSeconds(30));

            // Load HTML document with cancellation support
            using var document = new HTMLDocument();
            await document.NavigateAsync("example.html", cts.Token);

            // Create validator using WebAccessibility factory method
            var validator = new WebAccessibility().CreateValidator();

            // Perform validation
            ValidationResult result = validator.Validate(document);

            Console.WriteLine($"Validation success: {result.Success}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Validation was canceled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}