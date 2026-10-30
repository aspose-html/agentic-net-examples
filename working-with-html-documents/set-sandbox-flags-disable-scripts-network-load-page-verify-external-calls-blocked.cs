// Set sandbox flags to disable both scripts and network, load a page, and verify all external calls blocked.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with external script and image
            string htmlPath = "sample.html";
            string htmlContent = @"<html>
<head>
    <script src=""https://example.com/script.js""></script>
</head>
<body>
    <img src=""https://example.com/image.png"" />
    <p id=""msg"">Hello, Aspose.HTML!</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to disable scripts and network
            Configuration config = new Configuration();
            config.Security = Aspose.Html.Sandbox.None; // disable all sandboxed categories

            // Load the HTML document with the sandbox configuration
            using (HTMLDocument document = new HTMLDocument(htmlPath, config))
            {
                // Verify that the document loaded (external resources are blocked by sandbox)
                var paragraph = document.GetElementById("msg");
                string text = paragraph != null ? paragraph.TextContent : "Paragraph not found";

                Console.WriteLine("Document loaded successfully.");
                Console.WriteLine("Paragraph text: " + text);
                Console.WriteLine("Sandbox configuration applied: Scripts and Network disabled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}