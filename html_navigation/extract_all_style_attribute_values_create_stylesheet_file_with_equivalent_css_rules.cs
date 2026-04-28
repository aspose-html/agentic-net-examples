// Extract all style attribute values and create a stylesheet file containing equivalent CSS rules.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace ExtractStylesToCss
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                HTMLDocument document = new HTMLDocument(inputPath);
                NodeList allElements = document.QuerySelectorAll("*");
                StringBuilder cssBuilder = new StringBuilder();

                foreach (Element element in allElements)
                {
                    string style = element.GetAttribute("style");
                    if (!string.IsNullOrEmpty(style))
                    {
                        string selector = element.TagName.ToLower();

                        string id = element.GetAttribute("id");
                        if (!string.IsNullOrEmpty(id))
                        {
                            selector = $"#{id}";
                        }
                        else
                        {
                            string classAttr = element.GetAttribute("class");
                            if (!string.IsNullOrEmpty(classAttr))
                            {
                                string firstClass = classAttr.Split(' ')[0];
                                selector = $".{firstClass}";
                            }
                        }

                        cssBuilder.AppendLine($"{selector} {{{style}}}");
                    }
                }

                Element styleElement = document.CreateElement("style");
                styleElement.TextContent = cssBuilder.ToString();

                Element head = (Element)document.GetElementsByTagName("head")[0];
                head.AppendChild(styleElement);

                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}