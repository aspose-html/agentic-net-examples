// Convert all uppercase heading texts to title case while preserving their hash level markers.

using System;
using System.Globalization;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown input (could be replaced with file reading)
            string markdown = @"
# THIS IS A TITLE
## ANOTHER HEADING
### Mixed CASE Heading
Normal paragraph text.
#### YET ANOTHER UPPERCASE HEADING
";

            string[] lines = markdown.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int hashCount = 0;
                while (hashCount < line.Length && line[hashCount] == '#')
                    hashCount++;

                if (hashCount > 0 && (hashCount == line.Length || char.IsWhiteSpace(line[hashCount])))
                {
                    // Preserve leading hashes and following space(s)
                    int startIdx = hashCount;
                    while (startIdx < line.Length && char.IsWhiteSpace(line[startIdx]))
                        startIdx++;

                    string headingText = line.Substring(startIdx);
                    if (!string.IsNullOrEmpty(headingText) && headingText == headingText.ToUpperInvariant())
                    {
                        string titleCased = textInfo.ToTitleCase(headingText.ToLowerInvariant());
                        lines[i] = new string('#', hashCount) + " " + titleCased;
                    }
                }
            }

            string result = string.Join(Environment.NewLine, lines);
            Console.WriteLine("Modified Markdown:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}