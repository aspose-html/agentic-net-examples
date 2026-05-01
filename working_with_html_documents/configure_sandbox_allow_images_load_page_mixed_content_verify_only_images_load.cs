// Configure sandbox to allow images, load a page with mixed content, and verify only images load.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "mixed.html";
            string htmlContent = @"<html>
<head>
    <script>console.log('script executed');</script>
</head>
<body>
    <img src='https://via.placeholder.com/150' />
    <p>Sample text</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts; // block script execution, allow images

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var images = document.GetElementsByTagName("img");
                var scripts = document.GetElementsByTagName("script");

                Console.WriteLine($"Image elements loaded: {images.Length}");
                Console.WriteLine($"Script elements present: {scripts.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}