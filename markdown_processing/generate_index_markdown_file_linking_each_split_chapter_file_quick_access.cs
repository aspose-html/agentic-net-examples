// Generate an index Markdown file linking to each split chapter file for quick access.

using System;
using System.IO;
using System.Linq;

namespace IndexGenerator
{
    class Program
    {
        static void Main()
        {
            try
            {
                string chaptersDir = Path.Combine(Directory.GetCurrentDirectory(), "chapters");
                if (!Directory.Exists(chaptersDir))
                {
                    Console.WriteLine($"Directory not found: {chaptersDir}");
                    return;
                }

                var markdownFiles = Directory.GetFiles(chaptersDir, "*.md");
                var lines = markdownFiles.Select(f =>
                {
                    string fileName = Path.GetFileName(f);
                    string title = Path.GetFileNameWithoutExtension(f);
                    string relativePath = Path.Combine("chapters", fileName).Replace("\\", "/");
                    return $"* [{title}]({relativePath})";
                }).ToList();

                string indexPath = Path.Combine(Directory.GetCurrentDirectory(), "index.md");
                File.WriteAllLines(indexPath, lines);
                Console.WriteLine($"Index file created at {indexPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}