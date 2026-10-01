// Insert a base tag with a specified URL to resolve relative links correctly.

using System;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}