// Move a script element from the head to the end of the body to improve page loading.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title><script src='test.js'></script></head><body><h1>Hello</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            Aspose.Html.HTMLElement body = document.QuerySelector("body") as Aspose.Html.HTMLElement;

            if (head != null && body != null)
            {
                Aspose.Html.Collections.HTMLCollection scriptCollection = head.GetElementsByTagName("script");
                List<Aspose.Html.Dom.Element> scripts = new List<Aspose.Html.Dom.Element>();
                for (int i = 0; i < scriptCollection.Length; i++)
                {
                    scripts.Add((Aspose.Html.Dom.Element)scriptCollection[i]);
                }

                foreach (var script in scripts)
                {
                    head.RemoveChild(script);
                    body.AppendChild(script);
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}