// Demonstrate loading a protected HTML page using NTLM authentication and validate the response content.

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain network service (optional, shown for completeness)
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Prepare request with NTLM credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected.html");
            request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load the protected HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Validate response content
                string title = document.Title;
                System.Console.WriteLine("Document title: " + title);

                Aspose.Html.HTMLElement body = document.Body as Aspose.Html.HTMLElement;
                if (body != null)
                {
                    System.Console.WriteLine("Body content length: " + (body.InnerHTML?.Length ?? 0));
                }
                else
                {
                    System.Console.WriteLine("Body element not found.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}