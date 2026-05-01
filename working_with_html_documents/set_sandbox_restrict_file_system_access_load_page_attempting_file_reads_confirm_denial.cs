// Set sandbox to restrict file system access, load a page attempting file reads, and confirm denial.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // HTML that tries to read a local file via JavaScript
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sandbox Test</title></head>
<body>
<div id='result'>Initial</div>
<script>
fetch('file.txt')
  .then(r => r.text())
  .then(t => document.getElementById('result').innerText = t)
  .catch(e => document.getElementById('result').innerText = 'Error');
</script>
</body>
</html>";

            // Write the HTML to a temporary file
            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sandbox_test.html");
            System.IO.File.WriteAllText(tempPath, htmlContent);

            // Configure sandbox to block script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempPath, configuration))
            {
                // Attempt to read the element that the script would modify
                var resultElement = document.GetElementById("result");
                string output = resultElement != null ? resultElement.OuterHTML : "Element not found";
                Console.WriteLine(output);
                Console.WriteLine("If scripts are blocked, the file read attempt is denied.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}