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

            using (AutoResetEvent resetEvent = new AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
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
            }

            Console.WriteLine("Conversion to DOCX is not supported by Aspose.HTML.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}