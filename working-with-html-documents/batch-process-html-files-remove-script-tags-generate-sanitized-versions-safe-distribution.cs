// Batch process HTML files, remove all script tags, and generate sanitized versions for safe distribution.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "SanitizedHtml";
            System.IO.Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var scripts = document.GetElementsByTagName("script");
                    for (int i = scripts.Length - 1; i >= 0; i--)
                    {
                        var script = scripts[i];
                        if (script.ParentNode != null)
                        {
                            script.ParentNode.RemoveChild(script);
                        }
                    }

                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileName(htmlPath));
                    document.Save(outputPath);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}