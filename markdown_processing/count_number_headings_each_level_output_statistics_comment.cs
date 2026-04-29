// Count the number of headings at each level and output the statistics as a comment.

using System;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all heading elements
            var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

            // Count headings per level
            int[] counts = new int[7]; // indices 1-6 correspond to h1-h6
            for (int i = 0; i < headings.Length; i++)
            {
                HTMLElement element = (HTMLElement)headings[i];
                string tag = element.TagName.ToLower();
                int level = int.Parse(tag.Substring(1));
                counts[level]++;
            }

            // Build comment text with statistics
            StringBuilder commentBuilder = new StringBuilder();
            commentBuilder.Append("Heading counts: ");
            for (int level = 1; level <= 6; level++)
            {
                commentBuilder.Append($"h{level}={counts[level]} ");
            }

            // Insert comment at the beginning of the body
            var commentNode = document.CreateComment(commentBuilder.ToString().Trim());
            HTMLElement body = document.Body;
            if (body.FirstChild != null)
                body.InsertBefore(commentNode, body.FirstChild);
            else
                body.AppendChild(commentNode);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}