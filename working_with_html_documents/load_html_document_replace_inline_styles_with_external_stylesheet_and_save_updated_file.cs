// Load an HTML document, replace inline styles with external stylesheet references, and save the updated file.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

namespace ReplaceInlineStyles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = args.Length > 0 ? args[0] : "input.html";
                string outputPath = args.Length > 1 ? args[1] : "output.html";
                string cssPath = args.Length > 2 ? args[2] : "styles.css";

                HTMLDocument document = new HTMLDocument(inputPath);

                var nodesWithStyle = document.QuerySelectorAll("[style]");
                foreach (var node in nodesWithStyle)
                {
                    var element = node as Element;
                    element?.RemoveAttribute("style");
                }

                Element link = document.CreateElement("link");
                link.SetAttribute("rel", "stylesheet");
                link.SetAttribute("href", Path.GetFileName(cssPath));
                Element head = (Element)document.GetElementsByTagName("head").First();
                head.AppendChild(link);

                File.WriteAllText(cssPath, "/* External stylesheet */");

                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}