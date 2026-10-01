// Load a protected HTML page requiring NTLM authentication and ensure credentials are correctly applied.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Prepare request with NTLM credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected.html");
            request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load the protected HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}