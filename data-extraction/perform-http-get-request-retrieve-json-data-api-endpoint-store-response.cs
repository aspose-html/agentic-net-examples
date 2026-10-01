// Perform an HTTP GET request to retrieve JSON data from an API endpoint and store the response.

using System;
using System.IO;
using System.Text;

namespace AsposeHtmlJsonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/todos/1";
                string outputPath = "response.json";

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
                {
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(new Aspose.Html.Url(url));
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                    if (!response.IsSuccess)
                    {
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                        return;
                    }

                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    string json = Encoding.UTF8.GetString(contentBytes);
                    File.WriteAllText(outputPath, json);
                    Console.WriteLine($"JSON response saved to {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}