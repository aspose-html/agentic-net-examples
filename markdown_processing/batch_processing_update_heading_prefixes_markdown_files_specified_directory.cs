// Perform batch processing to update heading prefixes across all Markdown files in a specified directory.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputMarkdown";
            string outputFolder = @"C:\OutputMarkdown";
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);
            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                string content = File.ReadAllText(mdPath);
                string updated = Regex.Replace(content, @"^(#{1,6})\s*(.*)$", m =>
                {
                    string hashes = m.Groups[1].Value;
                    string title = m.Groups[2].Value.Trim();
                    return $"{hashes} Section {title}";
                }, RegexOptions.Multiline);
                string outPath = Path.Combine(outputFolder, Path.GetFileName(mdPath));
                File.WriteAllText(outPath, updated);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}