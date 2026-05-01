// Define an internal CSS rule to set the body background-color for the entire page and save.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

namespace ChangeBackgroundColor
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
                HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();
                body.Style.RemoveProperty("background-color");
                Element style = document.CreateElement("style");
                style.TextContent = "body { background-color: rgb(229, 243, 253) }";
                Element head = (Element)document.GetElementsByTagName("head").First();
                head.AppendChild(style);
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}