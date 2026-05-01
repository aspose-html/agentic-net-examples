// Load an HTML page, extract its title element text, and output the title to console.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            HTMLDocument document = new HTMLDocument(url);
            string title = document.Title;
            Console.WriteLine(title);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}