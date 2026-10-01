// Remove all script tags from the DOM to eliminate executable JavaScript before saving.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script type=""text/javascript"">
        console.log('Hello, world!');
    </script>
</head>
<body>
    <h1>Welcome</h1>
    <script>
        alert('This script will be removed.');
    </script>
    <p>Content without scripts.</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all script elements
            var scripts = document.GetElementsByTagName("script");

            // Iterate safely and remove
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // Save document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}