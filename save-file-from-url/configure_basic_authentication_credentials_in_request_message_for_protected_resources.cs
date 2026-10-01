// Configure basic authentication credentials in RequestMessage for protected resources.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create configuration
                var configuration = new Aspose.Html.Configuration();

                // Get network service
                var network = configuration.GetService<Aspose.Html.Services.INetworkService>();

                // Add a message handler to inspect Authorization header
                network.MessageHandlers.Add(new AuthValidator());

                // Create request with basic authentication
                var request = new Aspose.Html.Net.RequestMessage("https://example.com/protected");
                request.Credentials = new System.Net.NetworkCredential("user", "pass");
                request.PreAuthenticate = true;

                // Load the HTML document using the authenticated request
                using (var document = new Aspose.Html.HTMLDocument(request, configuration))
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

    public class AuthValidator : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            Next(context);
            string authValue = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authValue))
                System.Console.WriteLine("Authorization header present: " + authValue);
            else
                System.Console.WriteLine("Authorization header missing");
        }
    }
}