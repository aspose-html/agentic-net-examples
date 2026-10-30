// Enable sandboxing with ScriptsPolicy.Untrusted, load a web page, and verify scripts do not run.

namespace AsposeHtmlSandboxExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sandbox_test.html");
                string htmlContent = "<!DOCTYPE html><html><head><script>document.body.innerHTML += '<div id=\"scripted\">Hello</div>';</script></head><body></body></html>";
                System.IO.File.WriteAllText(tempFile, htmlContent);

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                configuration.Security |= Aspose.Html.Sandbox.Scripts;

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
                {
                    var element = document.GetElementById("scripted");
                    if (element != null)
                        System.Console.WriteLine("Script executed.");
                    else
                        System.Console.WriteLine("Script blocked.");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}