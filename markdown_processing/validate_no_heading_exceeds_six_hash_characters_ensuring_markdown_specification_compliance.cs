// Validate that no heading exceeds six hash characters, ensuring compliance with Markdown specifications.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Valid Heading\n###### Valid H6\n####### Invalid H7\nSome text";
            string[] lines = markdown.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                if (line.StartsWith("#"))
                {
                    int count = 0;
                    while (count < line.Length && line[count] == '#')
                        count++;
                    if (count > 6)
                    {
                        Console.WriteLine($"Heading exceeds six hash characters: \"{line}\"");
                    }
                }
            }

            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown));
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}