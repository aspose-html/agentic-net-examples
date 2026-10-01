// Detect mismatched Markdown delimiters and automatically correct them to maintain valid syntax.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><h1>Title</h1><p>This is *italic* and **bold** text.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Convert HTML to Markdown using Aspose.HTML
            string markdownPath = "generated.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read the generated Markdown
            string markdown = File.ReadAllText(markdownPath);

            // Introduce intentional mismatched delimiters for demonstration
            markdown += "\nHere is a code block:\n```csharp\nConsole.WriteLine(\"Hello\");\n";

            // Correct mismatched delimiters
            string corrected = CorrectMarkdownDelimiters(markdown);

            // Save corrected Markdown
            string correctedPath = "corrected.md";
            File.WriteAllText(correctedPath, corrected);

            Console.WriteLine("Original Markdown:");
            Console.WriteLine(markdown);
            Console.WriteLine("\nCorrected Markdown:");
            Console.WriteLine(corrected);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string CorrectMarkdownDelimiters(string input)
    {
        string output = input;

        // Balance triple backticks for code blocks
        int tripleBackticks = CountOccurrences(output, "```");
        if (tripleBackticks % 2 != 0)
        {
            output += "\n```";
        }

        // Balance single backticks for inline code (excluding those part of triple backticks)
        int singleBackticks = CountOccurrences(output, "`") - tripleBackticks * 3;
        if (singleBackticks % 2 != 0)
        {
            output += "`";
        }

        // Balance asterisks *
        int asterisks = CountOccurrences(output, "*");
        if (asterisks % 2 != 0)
        {
            output += "*";
        }

        // Balance underscores _
        int underscores = CountOccurrences(output, "_");
        if (underscores % 2 != 0)
        {
            output += "_";
        }

        // Balance brackets []
        int openBracket = CountOccurrences(output, "[");
        int closeBracket = CountOccurrences(output, "]");
        if (openBracket > closeBracket)
        {
            output += new string(']', openBracket - closeBracket);
        }
        else if (closeBracket > openBracket)
        {
            output = new string('[', closeBracket - openBracket) + output;
        }

        // Balance parentheses ()
        int openParen = CountOccurrences(output, "(");
        int closeParen = CountOccurrences(output, ")");
        if (openParen > closeParen)
        {
            output += new string(')', openParen - closeParen);
        }
        else if (closeParen > openParen)
        {
            output = new string('(', closeParen - openParen) + output;
        }

        return output;
    }

    static int CountOccurrences(string source, string value)
    {
        if (string.IsNullOrEmpty(value))
            return 0;

        int count = 0;
        int index = 0;
        while ((index = source.IndexOf(value, index, StringComparison.Ordinal)) != -1)
        {
            count++;
            index += value.Length;
        }
        return count;
    }
}