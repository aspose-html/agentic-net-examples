// Convert all heading texts to title case while keeping their existing hash level markers.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Original markdown content
            string markdown = @"
# sample heading one
## another heading two
Regular paragraph text.
### third level heading
";

            // Convert heading lines to title case while preserving hash markers
            string processedMarkdown = string.Join("\n",
                markdown.Split('\n')
                        .Select(line =>
                        {
                            string trimmed = line.TrimStart();
                            if (trimmed.StartsWith("#"))
                            {
                                int hashCount = 0;
                                while (hashCount < trimmed.Length && trimmed[hashCount] == '#')
                                    hashCount++;

                                int idx = hashCount;
                                while (idx < trimmed.Length && char.IsWhiteSpace(trimmed[idx]))
                                    idx++;

                                string headingText = trimmed.Substring(idx);
                                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                                string titleCase = ti.ToTitleCase(headingText.ToLower());

                                return new string('#', hashCount) + " " + titleCase;
                            }
                            return line;
                        })
            );

            // Load markdown into an HTML document
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(processedMarkdown)))
            {
                HTMLDocument document = Converter.ConvertMarkdown(stream, "");

                // Ensure a <head> element exists
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Save the resulting HTML
                document.Save("output.html");
            }

            Console.WriteLine("Conversion completed. HTML saved at output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}