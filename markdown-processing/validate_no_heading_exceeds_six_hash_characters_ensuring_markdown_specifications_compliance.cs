// Validate that no heading exceeds six hash characters, ensuring compliance with Markdown specifications.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize Aspose.HTML configuration (example usage)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Sample markdown content
            string markdown = @"# Title
## Subtitle
### Section
#### Subsection
##### Deep
###### TooDeep
####### Invalid";

            string[] lines = markdown.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            bool hasInvalid = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.StartsWith("#"))
                {
                    int hashCount = 0;
                    while (hashCount < line.Length && line[hashCount] == '#')
                    {
                        hashCount++;
                    }

                    if (hashCount > 6)
                    {
                        Console.WriteLine($"Invalid heading at line {i + 1}: {hashCount} hash characters.");
                        hasInvalid = true;
                    }
                }
            }

            if (!hasInvalid)
            {
                Console.WriteLine("All headings are valid (no more than six hash characters).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}