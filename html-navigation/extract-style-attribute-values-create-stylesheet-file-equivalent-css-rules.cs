// Extract all style attribute values and create a stylesheet file containing equivalent CSS rules.

using System;
using System.Text;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
</head>
<body>
    <div id='header' style='background-color:#f0f0f0; color:#333;'>Header</div>
    <p class='text' style='font-size:14px; margin:10px;'>Paragraph 1</p>
    <span style='display:inline-block; width:100px;'>Span</span>
</body>
</html>";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var elements = document.QuerySelectorAll("[style]");

            var cssBuilder = new StringBuilder();

            for (int i = 0; i < elements.Length; i++)
            {
                var element = (Aspose.Html.HTMLElement)elements[i];
                string styleValue = element.GetAttribute("style");
                if (string.IsNullOrEmpty(styleValue))
                    continue;

                string selector = $"{element.TagName.ToLowerInvariant()}_style_{i + 1}";
                cssBuilder.AppendLine($"{selector} {{{styleValue}}}");
            }

            string cssPath = "extracted-styles.css";
            File.WriteAllText(cssPath, cssBuilder.ToString());

            var head = document.QuerySelector("head");
            if (head != null)
            {
                var link = document.CreateElement("link");
                link.SetAttribute("rel", "stylesheet");
                link.SetAttribute("href", cssPath);
                head.AppendChild(link);
            }

            string outputHtmlPath = "output.html";
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}