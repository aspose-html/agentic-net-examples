// Demonstrate loading a protected HTML page using Basic authentication and validate the response content.

public class BasicAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;
    public BasicAuthHandler()
    {
        _credential = new System.Net.NetworkCredential("username", "password", "");
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new BasicAuthHandler());

            string url = "http://example.com/protected";

            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("Welcome"))
                {
                    System.Console.WriteLine("Protected page loaded successfully and contains expected content.");
                }
                else
                {
                    System.Console.WriteLine("Content validation failed or page is empty.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}