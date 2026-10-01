// Load an HTML page, disable JavaScript, and ensure dynamic navigation menus are not generated.

using System;
using Aspose.Html;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}