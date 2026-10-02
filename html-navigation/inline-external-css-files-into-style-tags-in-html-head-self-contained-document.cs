// Inline external CSS files into style tags within the HTML head for a self‑contained document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string baseDirectory = Directory.GetCurrentDirectory();
            string cssFilePath = Path.Combine(baseDirectory, "styles.css");
            string inputHtmlPath = Path.Combine(baseDirectory, "input.html");
            string outputHtmlPath = Path.Combine(baseDirectory, "output.html");

            // Create sample CSS file
            File.WriteAllText(cssFilePath, "p { color: blue; }");

            // Create sample HTML file referencing the external CSS
            string htmlContent = @"<html>
<head>
<link rel=""stylesheet"" href=""styles.css"">
</head>
<body>
<p>Hello, world!</p>
</body>
</html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Process all <link rel=""stylesheet""> elements
            var links = document.GetElementsByTagName("link");
            for (int i = links.Length - 1; i >= 0; i--)
            {
                var link = (Aspose.Html.HTMLElement)links[i];
                string rel = link.GetAttribute("rel");
                if (!string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = link.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve CSS file path relative to the HTML file
                string cssPath = Path.Combine(Path.GetDirectoryName(inputHtmlPath) ?? string.Empty, href);
                if (!File.Exists(cssPath))
                    continue;

                // Read CSS content
                string cssContent = File.ReadAllText(cssPath);

                // Create <style> element and set its content
                var styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
                styleElement.TextContent = cssContent;

                // Append the <style> element to <head>
                var head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head")[0];
                head.AppendChild(styleElement);

                // Remove the original <link> element
                var parent = link.ParentNode;
                if (parent != null)
                {
                    parent.RemoveChild(link);
                }
            }

            // Save the modified document
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}