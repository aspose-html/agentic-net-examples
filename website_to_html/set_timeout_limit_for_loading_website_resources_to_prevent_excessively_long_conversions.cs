// Set a timeout limit for loading website resources to prevent excessively long conversions.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            RequestMessage request = new RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(30);
            using (HTMLDocument document = new HTMLDocument(request))
            {
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}