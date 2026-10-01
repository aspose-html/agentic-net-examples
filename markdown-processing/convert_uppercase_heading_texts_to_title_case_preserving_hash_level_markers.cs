// Convert all uppercase heading texts to title case while preserving their hash level markers.

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "input.md";
            string outputPath = "output.html";

            // Create a sample markdown file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sample = "# SAMPLE HEADING\n" +
                                "Some regular text.\n" +
                                "## ANOTHER HEADING\n" +
                                "More content.\n" +
                                "### THIRD LEVEL HEADING";
                File.WriteAllText(inputPath, sample);
            }

            // Read and process markdown lines
            string[] lines = File.ReadAllLines(inputPath);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string trimmed = line.TrimStart();
                if (trimmed.StartsWith("#"))
                {
                    int hashCount = 0;
                    while (hashCount < line.Length && line[hashCount] == '#')
                        hashCount++;

                    string afterHashes = line.Substring(hashCount).Trim();
                    if (!string.IsNullOrEmpty(afterHashes))
                    {
                        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                        string titleCase = ti.ToTitleCase(afterHashes.ToLower());
                        lines[i] = new string('#', hashCount) + " " + titleCase;
                    }
                }
            }

            // Combine processed markdown
            string processedMarkdown = string.Join("\n", lines);

            // Convert markdown to HTMLDocument
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(processedMarkdown)))
            {
                HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");

                // Save HTML to file
                document.Save(outputPath);
            }

            // Compute SHA-256 hash of the output file
            byte[] outputBytes = File.ReadAllBytes(outputPath);
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(outputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                Console.WriteLine($"Output Path: {outputPath}");
                Console.WriteLine($"SHA-256 Hash: {hashString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}