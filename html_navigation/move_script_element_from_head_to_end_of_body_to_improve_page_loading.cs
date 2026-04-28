// Move a script element from the head to the end of the body to improve page loading.

using System;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <inputHtmlPath> <outputHtmlPath>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the <head> and <body> elements
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            Aspose.Html.HTMLElement body = document.Body as Aspose.Html.HTMLElement;

            if (head == null || body == null)
                throw new InvalidOperationException("Document must contain both <head> and <body> elements.");

            // Get all <script> elements in the document
            Aspose.Html.Collections.HTMLCollection scripts = document.GetElementsByTagName("script");

            // Move scripts that are currently inside <head> to the end of <body>
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element script = (Aspose.Html.Dom.Element)scripts[i];
                if (script.ParentNode == head)
                {
                    body.AppendChild(script);
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}