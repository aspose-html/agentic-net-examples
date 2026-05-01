// Load an HTML page, disable JavaScript, and ensure dynamic navigation menus are not generated.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        string url = "https://example.com";

        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}