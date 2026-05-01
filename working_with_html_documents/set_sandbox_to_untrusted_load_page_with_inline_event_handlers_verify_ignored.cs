// Set sandbox to untrusted, load a page with inline event handlers, and verify they are ignored.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script>document.body.innerHTML='script executed';</script></head><body>Original Content</body></html>";
            string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sandbox_test.html");
            System.IO.File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Document OuterHTML:");
                Console.WriteLine(output);

                var body = document.GetElementsByTagName("body")[0];
                string bodyText = body != null ? body.TextContent : string.Empty;
                Console.WriteLine("Body TextContent:");
                Console.WriteLine(bodyText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}