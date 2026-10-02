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

            // Create an empty HTMLDocument with the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(configuration))
            {
                // Define the request URL
                Aspose.Html.Url url = new Aspose.Html.Url("https://example.com");

                // Create a request message
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);

                // Send the request and obtain the response
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                // Output basic response information
                bool isSuccess = response.IsSuccess;
                Console.WriteLine("Request succeeded: " + isSuccess);
                byte[] contentBytes = response.Content.ReadAsByteArray();
                Console.WriteLine("Response content length: " + contentBytes.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}