// Send the request via Document.Send (or SendAsync) and obtain a ResponseMessage.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string urlString = "https://example.com";
            Aspose.Html.Url url = new Aspose.Html.Url(urlString);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                System.Console.WriteLine("Status code: " + response.StatusCode);
                byte[] contentBytes = response.Content.ReadAsByteArray();
                System.Console.WriteLine("Content length: " + contentBytes.Length);
                string content = System.Text.Encoding.UTF8.GetString(contentBytes);
                System.Console.WriteLine("First 200 characters:");
                System.Console.WriteLine(content.Substring(0, System.Math.Min(200, content.Length)));
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}