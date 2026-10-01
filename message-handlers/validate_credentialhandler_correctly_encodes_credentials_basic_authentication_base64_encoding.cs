// Validate that CredentialHandler correctly encodes credentials for Basic authentication using Base64 encoding.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialValidator());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/");
            request.Credentials = new System.Net.NetworkCredential("user", "pass");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class CredentialValidator : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authValue = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authValue))
            Console.WriteLine("Authorization header present: " + authValue);
        else
            Console.WriteLine("Authorization header missing");
    }
}