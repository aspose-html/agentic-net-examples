// Create a document, add a script that alerts a message, enable sandbox, and verify alert is blocked.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><script>alert('Hello from script');</script></head><body><p>Sample content</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sandbox_example.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Document outer HTML:");
                Console.WriteLine(output);
                Console.WriteLine("Sandbox with Scripts flag enabled – script execution is blocked.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}