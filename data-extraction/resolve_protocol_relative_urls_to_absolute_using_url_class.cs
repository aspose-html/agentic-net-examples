// Resolve protocol‑relative URLs (starting with //) to absolute URLs using the Url class.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Base URL for resolution
            string baseUrl = "https://mydomain.com";
            // Protocol‑relative URL
            string relativeUrl = "//example.com/image.png";
            // Resolve to absolute URL
            Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(baseUrl, relativeUrl);
            Console.WriteLine("Absolute URL: " + absoluteUrl.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}