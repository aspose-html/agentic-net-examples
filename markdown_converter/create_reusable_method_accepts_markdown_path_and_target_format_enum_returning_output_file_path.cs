// Create a reusable method that accepts a Markdown path and target format enum, returning the output file path.

using System;
using System.IO;
using Aspose.Html.Converters;

namespace AsposeHtmlDemo
{
    enum TargetFormat
    {
        Html,
        Markdown
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Example usage: convert a markdown file to HTML
                string markdownPath = @"C:\Temp\sample.md";
                string resultPath = ConvertMarkdown(markdownPath, TargetFormat.Html);
                Console.WriteLine($"Converted file saved at: {resultPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Converts a markdown file to the specified target format and returns the output file path.
        /// </summary>
        /// <param name="markdownPath">Path to the source markdown file.</param>
        /// <param name="format">Desired output format.</param>
        /// <returns>Path to the generated output file.</returns>
        public static string ConvertMarkdown(string markdownPath, TargetFormat format)
        {
            if (string.IsNullOrEmpty(markdownPath))
                throw new ArgumentException("Markdown path cannot be null or empty.", nameof(markdownPath));

            string outputPath;
            switch (format)
            {
                case TargetFormat.Html:
                    // Determine output HTML file path
                    outputPath = Path.ChangeExtension(markdownPath, ".html");
                    // Rule: define source and output paths, then convert markdown to HTML
                    string sourcePath = markdownPath;
                    string htmlOutputPath = outputPath;
                    Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, htmlOutputPath);
                    break;

                case TargetFormat.Markdown:
                    // If target is markdown, simply copy the source file
                    outputPath = Path.ChangeExtension(markdownPath, ".converted.md");
                    File.Copy(markdownPath, outputPath, true);
                    break;

                default:
                    throw new NotSupportedException($"The format '{format}' is not supported.");
            }

            return outputPath;
        }
    }
}