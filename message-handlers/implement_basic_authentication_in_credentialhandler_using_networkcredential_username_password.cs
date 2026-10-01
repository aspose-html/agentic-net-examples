// Implement Basic authentication in CredentialHandler using NetworkCredential with username and password.

namespace Example
{
    class CredentialHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly System.Net.NetworkCredential _credential;
        public CredentialHandler()
        {
            _credential = new System.Net.NetworkCredential("username", "password");
        }
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Credentials = _credential;
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new CredentialHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("http://example.com/protected", configuration))
                {
                    string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                    System.Console.WriteLine("Loaded HTML length: " + html.Length);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}