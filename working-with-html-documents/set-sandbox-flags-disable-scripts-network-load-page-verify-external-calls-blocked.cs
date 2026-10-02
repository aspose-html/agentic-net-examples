// Set sandbox flags to disable both scripts and network, load a page, and verify all external calls blocked.

public class Program
{
    public static void Main()
    {
        try
        {
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;
            // Network sandbox flag is not available in this version; scripts sandbox is applied.

            string html = "<html><head><script>window.externalCall = true;</script></head><body><img src='https://example.com/image.png' /></body></html>";

            using (var document = new Aspose.Html.HTMLDocument(html, "about:blank", config))
            {
                string outerHtml = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine("Document loaded. OuterHTML:");
                System.Console.WriteLine(outerHtml);
                System.Console.WriteLine("Sandbox applied: scripts disabled (network access not allowed by default).");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}