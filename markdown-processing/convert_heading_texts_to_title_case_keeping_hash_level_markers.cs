// Convert all heading texts to title case while keeping their existing hash level markers.

using System;
using System.IO;
using System.Text;
using System.Globalization;
using Aspose.Html.Converters;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content with headings
            string markdown = "# hello world\n## sample heading\nRegular paragraph.\n### another heading example";

            // Convert headings to title case while preserving hash markers
            StringBuilder processedBuilder = new StringBuilder();
            using (StringReader reader = new StringReader(markdown))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("#"))
                    {
                        int hashCount = 0;
                        while (hashCount < line.Length && line[hashCount] == '#')
                            hashCount++;

                        // Expect a space after hashes
                        int textStart = hashCount;
                        if (textStart < line.Length && line[textStart] == ' ')
                            textStart++;

                        string headingText = line.Substring(textStart);
                        string titleCased = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(headingText.ToLower());

                        string newLine = new string('#', hashCount) + " " + titleCased;
                        processedBuilder.AppendLine(newLine);
                    }
                    else
                    {
                        processedBuilder.AppendLine(line);
                    }
                }
            }

            string processedMarkdown = processedBuilder.ToString();

            // Convert processed markdown to HTML
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(processedMarkdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "utf-8");

                // Save HTML to file
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);

                Console.WriteLine("HTML saved at: " + outputPath);
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}