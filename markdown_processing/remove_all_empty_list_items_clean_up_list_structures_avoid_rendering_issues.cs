// Remove all empty list items to clean up list structures and avoid rendering issues.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using System.Linq;

namespace RemoveEmptyListItems
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
                    HTMLCollection listItems = document.GetElementsByTagName("li");
                    foreach (Element li in listItems.ToList())
                    {
                        if (string.IsNullOrWhiteSpace(li.InnerHTML))
                        {
                            li.ParentNode.RemoveChild(li);
                        }
                    }
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}