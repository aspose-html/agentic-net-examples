// Configure HtmlDocument to ignore script errors during page loading.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            Configuration config = new Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;
            HTMLDocument doc = new HTMLDocument("input.html", config);
            string html = ((HTMLElement)doc.DocumentElement).OuterHTML;
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}