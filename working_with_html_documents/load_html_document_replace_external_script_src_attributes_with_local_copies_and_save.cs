// Load an HTML document, replace all external script src attributes with local copies, and save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace ScriptSrcReplacer
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";
                HTMLDocument document = new HTMLDocument(inputPath);
                HTMLCollection scriptElements = document.GetElementsByTagName("script");
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Element scriptElement = (Element)scriptElements[i];
                    string src = scriptElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src) && (src.StartsWith("http://") || src.StartsWith("https://")))
                    {
                        string fileName = System.IO.Path.GetFileName(new Uri(src).AbsolutePath);
                        string localPath = "scripts/" + fileName;
                        scriptElement.SetAttribute("src", localPath);
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
}