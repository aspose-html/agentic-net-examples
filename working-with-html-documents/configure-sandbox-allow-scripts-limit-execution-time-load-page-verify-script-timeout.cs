// Configure sandbox to allow scripts but limit execution time, load a page, and verify script timeout.

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Set JavaScript execution timeout
            Aspose.Html.Services.IRuntimeService runtimeService = configuration.GetService<Aspose.Html.Services.IRuntimeService>();
            if (runtimeService != null)
            {
                runtimeService.JavaScriptTimeout = System.TimeSpan.FromSeconds(2);
            }

            // HTML content with an infinite loop script
            string htmlContent = "<html><body><script>while(true) {}</script></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");

            // Load the document with the configured sandbox and timeout
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri, configuration))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                System.Console.WriteLine("Document loaded. Text length: " + text.Length);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}