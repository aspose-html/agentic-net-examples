// Resolve protocol‑relative URLs (starting with //) to absolute URLs using the Url class.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Base URL of the document (provides the scheme)
            string baseUrl = "https://www.example.com/page.html";

            // Protocol‑relative URL to be resolved
            string protocolRelative = "//cdn.example.com/script.js";

            // Resolve to an absolute URL using the Url constructor with a base URL
            Url absoluteUrl = new Url(protocolRelative, baseUrl);

            // Output the resolved absolute URL
            Console.WriteLine("Absolute URL: " + absoluteUrl.ToString());
        }
        catch (Exception ex)
        {
            // Handle any errors that may occur during resolution
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}