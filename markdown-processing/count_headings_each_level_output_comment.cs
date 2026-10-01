// Count the number of headings at each level and output the statistics as a comment.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Title</h1><h2>Section</h2><h2>Another</h2><h3>Sub</h3></body></html>");
            }
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
            var counts = new Dictionary<int, int>();
            for (int i = 0; i < headings.Length; i++)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)headings[i];
                string tag = element.TagName.ToLower();
                int level = int.Parse(tag.Substring(1));
                if (counts.ContainsKey(level))
                    counts[level]++;
                else
                    counts[level] = 1;
            }
            string commentText = "Heading counts: " + string.Join(", ", counts.OrderBy(kv => kv.Key).Select(kv => $"h{kv.Key}={kv.Value}"));
            var commentNode = document.CreateComment("\n" + commentText + "\n");
            document.InsertBefore(commentNode, document.DocumentElement);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}