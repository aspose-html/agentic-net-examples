// Save the modified HTML document back to the original file location.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"old\"><title>Test</title></head><body><p>Hello</p></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "new description");
                    }
                }

                document.Save(inputPath);
            }

            System.Console.WriteLine("Document saved successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}