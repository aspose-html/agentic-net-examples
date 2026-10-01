// Set the HTTP method to GET in RequestMessage.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Create request and set HTTP method to GET
            using (Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com"))
            {
                request.Method = Aspose.Html.Net.HttpMethod.Get;

                // Load the HTML document using the request
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    Console.WriteLine("Document loaded. Title: " + document.Title);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}