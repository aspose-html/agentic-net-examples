// Create a document, add a script that alerts a message, enable sandbox, and verify alert is blocked.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content with a script that shows an alert
            string htmlContent = "<html><head><script>alert('Hello');</script></head><body><p>Test</p></body></html>";

            // Create a temporary file path to store the HTML
            string tempFile = Path.Combine(Path.GetTempPath(), "sandbox_test.html");

            // Write the HTML content to the temporary file
            File.WriteAllText(tempFile, htmlContent);

            // Create a configuration and enable the sandbox Scripts flag to block script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                // Output the document's outer HTML (script is present but will not execute)
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}