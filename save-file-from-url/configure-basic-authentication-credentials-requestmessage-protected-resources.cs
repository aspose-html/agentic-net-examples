// Configure basic authentication credentials in RequestMessage for protected resources.

namespace Example
{
    class AuthValidator : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            Next(context);
            string authHeader = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader))
                System.Console.WriteLine("Authorization header present: " + authHeader);
            else
                System.Console.WriteLine("Authorization header missing");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new AuthValidator());

                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com/protected");
                request.Credentials = new System.Net.NetworkCredential("user", "pass");
                request.PreAuthenticate = true;

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
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