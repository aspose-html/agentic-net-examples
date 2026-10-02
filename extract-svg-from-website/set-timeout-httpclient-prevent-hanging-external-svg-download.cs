// Set a timeout on HttpClient to prevent hanging during external SVG download.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/sample.svg";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(5);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request))
            {
                string outputPath = "sample.svg";
                document.Save(outputPath);
                System.Console.WriteLine($"SVG saved to {outputPath}");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}