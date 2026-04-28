// Remove all noscript elements to simplify the DOM for environments without JavaScript.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace RemoveNoscript
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    HTMLCollection noscripts = document.GetElementsByTagName("noscript");
                    foreach (Element noscript in noscripts)
                    {
                        noscript.ParentNode.RemoveChild(noscript);
                    }
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}