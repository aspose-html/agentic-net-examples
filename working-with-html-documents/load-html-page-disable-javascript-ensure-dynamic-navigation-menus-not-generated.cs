// Load an HTML page, disable JavaScript, and ensure dynamic navigation menus are not generated.

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security = Aspose.Html.Sandbox.None; // Disable scripts and other sandboxed features

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
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

                    if (document.ReadyState == "complete")
                    {
                        htmlResult = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                    }
                    else
                    {
                        resetEvent.WaitOne();
                    }

                    System.Console.WriteLine(htmlResult);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}