// Use a using block to ensure RequestMessage and ResponseMessage are disposed after the operation.

using System;
using Aspose.Html;
using Aspose.Html.Net;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a request message and ensure it is disposed after use
                using (RequestMessage request = new RequestMessage("https://www.example.com"))
                {
                    // Load the HTML document using the request and ensure disposal
                    using (HTMLDocument document = new HTMLDocument(request))
                    {
                        Console.WriteLine("Document title: " + document.Title);
                    }

                    // Create a response message and ensure it is disposed after use
                    using (ResponseMessage response = new ResponseMessage(System.Net.HttpStatusCode.OK))
                    {
                        Console.WriteLine("Response status: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}