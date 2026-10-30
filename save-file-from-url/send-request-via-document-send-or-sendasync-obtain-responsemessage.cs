// Send the request via Document.Send (or SendAsync) and obtain a ResponseMessage.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Create an empty HTML document with a base URI
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("about:blank", configuration))
            {
                // Prepare request
                Aspose.Html.Url url = new Aspose.Html.Url("https://example.com");
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                // Send request and obtain response
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Output response information
                System.Console.WriteLine("Status Code: " + response.StatusCode);
                System.Console.WriteLine("Success: " + response.IsSuccess);
                System.Console.WriteLine("Content Length (bytes): " + response.Content.ReadAsByteArray().Length);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}