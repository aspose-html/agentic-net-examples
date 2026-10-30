// Set sandbox to restrict file system access, load a page attempting file reads, and confirm denial.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create a temporary HTML file that attempts to load a local script file
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlSandboxDemo");
            Directory.CreateDirectory(tempDir);

            string scriptFilePath = Path.Combine(tempDir, "localScript.js");
            File.WriteAllText(scriptFilePath, "console.log('This should not run');");

            string htmlFilePath = Path.Combine(tempDir, "test.html");
            string htmlContent = $"<html><head><script src=\"{scriptFilePath}\"></script></head><body><p>Sandbox test</p></body></html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Configure sandbox to restrict script execution (which also blocks file access from scripts)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Attempt to load the HTML document with the restricted sandbox
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration))
            {
                // If loading succeeds, output the document's outer HTML
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Document loaded successfully. OuterHTML:");
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            // Expected: script loading should be denied by the sandbox
            Console.WriteLine("An exception occurred, indicating sandbox restriction:");
            Console.WriteLine(ex.Message);
        }
    }
}