// Load an HTML page, disable JavaScript execution, and ensure dynamic content does not appear.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
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