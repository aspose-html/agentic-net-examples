// Implement an authentication handler that validates required headers and returns error response when missing.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class AuthHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["Authorization"]))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new AuthHandler());

            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}