// Enable sandboxing with ScriptsPolicy.Untrusted, load a web page, and verify scripts do not run.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                var html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}