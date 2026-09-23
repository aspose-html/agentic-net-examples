// Perform an HTTP GET request to retrieve JSON data from an API endpoint and store the response.

using System;
using System.IO;
using System.Text;

namespace AsposeHtmlJsonExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/todos/1";
                string outputPath = "response.json";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
                {
                    Aspose.Html.Url requestUrl = new Aspose.Html.Url(url);
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUrl);
                    Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        byte[] contentBytes = response.Content.ReadAsByteArray();
                        string json = Encoding.UTF8.GetString(contentBytes);
                        File.WriteAllText(outputPath, json);
                        Console.WriteLine("JSON saved to " + outputPath);
                    }
                    else
                    {
                        Console.WriteLine("Request failed. Status code: " + response.StatusCode);
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