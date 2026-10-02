// Set sandbox flags to disable network access, load a page with external resources, and confirm they are blocked.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with external script
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <script src=""https://example.com/external.js""></script>
</head>
<body>
    <div id=""test"">Original</div>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox: enable scripts but do NOT enable network access
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts; // allow scripts
            // Note: Network flag is NOT set, so network access is disabled

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Retrieve the element and check its content
                var element = document.GetElementById("test");
                string innerHtml = null;
                if (element != null && element is Aspose.Html.HTMLElement htmlElement)
                {
                    innerHtml = htmlElement.InnerHTML;
                }

                Console.WriteLine("Content of #test element: " + (innerHtml ?? "null"));
                // Expected output: "Original" because external script could not be loaded
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}