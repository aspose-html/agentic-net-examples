// Apply a custom CSS class to all code block nodes by modifying their syntax properties.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<html><body><h1>Example</h1><pre><code>var x = 1;</code></pre><code>console.log('test');</code></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("code");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.SetAttribute("class", "custom-code");
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}