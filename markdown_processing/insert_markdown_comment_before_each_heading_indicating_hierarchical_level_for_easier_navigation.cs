// Insert a Markdown comment before each heading indicating its hierarchical level for easier navigation.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace InsertMarkdownComments
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                HTMLDocument doc = new HTMLDocument(inputPath);
                var headings = doc.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement element = (HTMLElement)headings[i];
                    string tag = element.TagName.ToLower();
                    int level = int.Parse(tag.Substring(1));
                    Comment comment = doc.CreateComment($" Level {level} ");
                    element.ParentNode.InsertBefore(comment, element);
                }
                doc.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}