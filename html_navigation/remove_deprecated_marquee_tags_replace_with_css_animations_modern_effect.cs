// Remove all deprecated <marquee> tags and replace them with CSS animations for modern effect.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace RemoveMarquee
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

                var head = document.GetElementsByTagName("head").First() as HTMLElement;
                var style = document.CreateElement("style");
                style.TextContent = ".marquee-replacement { overflow:hidden; white-space:nowrap; display:inline-block; animation:marquee 10s linear infinite; } @keyframes marquee { from { transform:translateX(100%); } to { transform:translateX(-100%); } }";
                head.AppendChild(style);

                HTMLCollection marquees = document.GetElementsByTagName("marquee");
                foreach (Element marquee in marquees)
                {
                    var div = document.CreateElement("div");
                    div.SetAttribute("class", "marquee-replacement");
                    div.InnerHTML = marquee.InnerHTML;
                    marquee.ParentNode.ReplaceChild(div, marquee);
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