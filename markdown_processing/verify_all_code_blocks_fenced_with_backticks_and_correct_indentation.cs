// Verify that all code blocks are fenced with backticks and correct any that use indentation.

using System;
using System.IO;
using System.Text;

namespace CodeBlockVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Usage: CodeBlockVerifier <path-to-markdown-file>");
                    return;
                }

                string path = args[0];
                if (!File.Exists(path))
                {
                    Console.WriteLine($"File not found: {path}");
                    return;
                }

                string[] lines = File.ReadAllLines(path);
                var corrected = new StringBuilder();
                bool inIndentedBlock = false;

                foreach (string rawLine in lines)
                {
                    string line = rawLine;
                    bool isIndented = line.StartsWith("    ") || line.StartsWith("\t");
                    bool isFenced = line.TrimStart().StartsWith("```");

                    if (isFenced)
                    {
                        if (inIndentedBlock)
                        {
                            corrected.AppendLine("```");
                            inIndentedBlock = false;
                        }
                        corrected.AppendLine(line);
                        continue;
                    }

                    if (isIndented)
                    {
                        if (!inIndentedBlock)
                        {
                            corrected.AppendLine("```");
                            inIndentedBlock = true;
                        }
                        corrected.AppendLine(line.TrimStart());
                    }
                    else
                    {
                        if (inIndentedBlock)
                        {
                            corrected.AppendLine("```");
                            inIndentedBlock = false;
                        }
                        corrected.AppendLine(line);
                    }
                }

                if (inIndentedBlock)
                {
                    corrected.AppendLine("```");
                }

                Console.WriteLine("Corrected Content:");
                Console.WriteLine(corrected.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}