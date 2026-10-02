// Enable sandboxing with ScriptsPolicy.Untrusted, load a web page, and verify scripts do not run.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script>document.body.setAttribute('data-script','executed');</script></head><body id='body'>Hello</body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sandbox_test.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                var element = document.GetElementById("body");
                string attr = element != null ? element.GetAttribute("data-script") : null;
                Console.WriteLine(attr ?? "Script not executed");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}