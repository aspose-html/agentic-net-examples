// Create a RequestMessage with custom headers and use it to download an image file from a URL.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string imageUrl = "https://example.com/sample.jpg";
            string outputPath = "sample.jpg";

            Aspose.Html.Url url = new Aspose.Html.Url(imageUrl);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Headers.Add("User-Agent", "Aspose-HTML-Example");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                if (response.IsSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    System.IO.File.WriteAllBytes(outputPath, contentBytes);
                    System.Console.WriteLine("Image downloaded successfully to " + outputPath);
                }
                else
                {
                    System.Console.WriteLine("Failed to download image.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}