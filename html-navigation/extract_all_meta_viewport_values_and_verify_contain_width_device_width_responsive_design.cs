// Extract all meta viewport values and verify they contain width=device‑width for responsive design.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<meta name=""viewport"" content=""initial-scale=1"">
<title>Test</title>
</head>
<body></body>
</html>";
            File.WriteAllText(tempPath, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempPath))
            {
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("meta");
                bool allContainWidth = true;
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)elements[i];
                    string nameAttr = element.GetAttribute("name");
                    if (nameAttr != null && nameAttr.Equals("viewport", StringComparison.OrdinalIgnoreCase))
                    {
                        string contentAttr = element.GetAttribute("content");
                        if (contentAttr == null || !contentAttr.Contains("width=device-width"))
                        {
                            allContainWidth = false;
                            Console.WriteLine($"Meta viewport tag at index {i} does not contain width=device-width.");
                        }
                    }
                }

                if (allContainWidth)
                {
                    Console.WriteLine("All meta viewport tags contain width=device-width.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}