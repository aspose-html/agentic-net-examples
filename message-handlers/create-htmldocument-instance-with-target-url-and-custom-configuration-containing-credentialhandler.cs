// Create an HTMLDocument instance with a target URL and the custom Configuration containing CredentialHandler.

namespace Example
{
    class CredentialHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly System.Net.ICredentials _credentials;

        public CredentialHandler(System.Net.ICredentials credentials)
        {
            _credentials = credentials;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Credentials = _credentials;
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
                CredentialHandler credentialHandler = new CredentialHandler(new System.Net.NetworkCredential("user", "password"));
                network.MessageHandlers.Add(credentialHandler);

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
                {
                    document.Save("output.html");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}