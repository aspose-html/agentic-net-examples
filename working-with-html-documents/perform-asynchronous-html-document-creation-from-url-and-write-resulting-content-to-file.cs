// Perform asynchronous HTML document creation from a URL, and write the resulting content to a file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                string htmlResult = string.Empty;
                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        htmlResult = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                        resetEvent.Set();
                    }
                };
                document.Navigate(url);
                resetEvent.WaitOne();

                document.Save(outputPath);
                System.Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}