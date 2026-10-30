// Move a script element from the head to the end of the body to improve page loading.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input HTML file
            string inputPath = "input.html";
            string outputPath = "output.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <script src=""sample.js""></script>
</head>
<body>
    <h1>Hello World</h1>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Configure behavior to allow scripts (optional)
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load document with configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Access head and body elements
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            Aspose.Html.HTMLElement body = document.QuerySelector("body") as Aspose.Html.HTMLElement;

            if (head != null && body != null)
            {
                // Collect script elements from head
                Aspose.Html.Collections.HTMLCollection scriptCollection = head.GetElementsByTagName("script");
                List<Aspose.Html.Dom.Element> scripts = new List<Aspose.Html.Dom.Element>();
                for (int i = 0; i < scriptCollection.Length; i++)
                {
                    scripts.Add((Aspose.Html.Dom.Element)scriptCollection[i]);
                }

                // Move each script to the end of the body
                foreach (Aspose.Html.Dom.Element script in scripts)
                {
                    head.RemoveChild(script);
                    body.AppendChild(script);
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}