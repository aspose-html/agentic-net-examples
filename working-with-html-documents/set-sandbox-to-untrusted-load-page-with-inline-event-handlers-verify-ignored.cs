// Set sandbox to untrusted, load a page with inline event handlers, and verify they are ignored.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Original</title><script>document.title = 'Changed';</script></head><body><button id='btn' onclick=\"document.title='Clicked'\">Click</button></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sandbox_test.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            // No sandbox flags are set, keeping the sandbox untrusted (scripts are disabled)

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, config))
            {
                string title = document.Title;
                Console.WriteLine("Document title after loading: " + title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}