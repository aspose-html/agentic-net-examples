// Set the HTTP method to GET in RequestMessage.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
            request.Method = Aspose.Html.Net.HttpMethod.Get;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document loaded. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}