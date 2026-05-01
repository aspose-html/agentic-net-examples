// Implement a callback that logs document load completion, then convert the loaded HTML to DOCX.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.docx";

            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (HTMLDocument document = new HTMLDocument())
            {
                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        Console.WriteLine("Document load completed.");
                        resetEvent.Set();
                    }
                };

                document.Navigate(url);
                resetEvent.WaitOne();

                var saveOptions = new DocSaveOptions();
                Converter.ConvertHTML(document, saveOptions, outputPath);
                Console.WriteLine($"Document saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}